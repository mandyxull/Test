user  nginx;
worker_processes  1;

error_log  /var/log/nginx/error.log warn;
pid        /var/run/nginx.pid;


events {
    worker_connections  1024;
}


http {
    include       /etc/nginx/mime.types;
    default_type  application/octet-stream;

    log_format  main  '$remote_addr - $remote_user [$time_local] "$request" '
                      '$status $body_bytes_sent "$http_referer" '
                      '"$http_user_agent" "$http_x_forwarded_for"';

    access_log  /var/log/nginx/access.log  main;

    sendfile        on;
    #tcp_nopush     on;

    keepalive_timeout  65;

    #gzip  on;

    upstream NETCoreSite{
        server 59.110.160.128:8081 weight=1;
        server 59.110.160.128:8082 weight=10;
        server 59.110.160.128:8083 weight=20;
        #默认就是轮询的  权重模式
    }

    server {
        listen       8085;
        listen       [::]:8085;
        server_name  59.110.160.128;
        root         /usr/share/nginx/html;

        #include /etc/nginx/conf.d/*.conf;

        location / {
             proxy_pass http://NETCoreSite;
             proxy_set_header Host $host;
             index  index.html index.htm;
        }
       
        error_page   500 502 503 504  /50x.html;
        location = /50x.html {
            root   html;
        }

        location = /favicon.ico {
            log_not_found off;
            access_log off;
        }
    }
    
}



