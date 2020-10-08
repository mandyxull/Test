using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Mandy.Blog.BackgroundJobs;
using Mandy.Blog.BackgroundJobs.Jobs;
using Mandy.Blog.Domain.Configurations;
using Mandy.Blog.EntityFrameworkCore;
using Mandy.Blog.HttpApi.Hosting.Filters;
using Mandy.Blog.HttpApi.Hosting.Middleware;
using Mandy.Blog.Swagger;
using Mandy.Blog.ToolKits.Base;
using Mandy.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Mandy.Blog.HttpApi.Hosting
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(MandyBlogHttpApiModule),
        typeof(MandyBlogSwaggerModule),
        typeof(MandyBlogFrameworkCoreModule),
        typeof(MandyBlogEntityFrameworkCoreDbMigrationsModule),
        typeof(MandyBlogBackgroundJobsModule)
        )]
    public class MandyBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {           
            // 身份验证
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,//是否验证颁发者
                           ValidateAudience = true,//是否验证访问群体
                           ValidateLifetime = true,//是否验证生存期
                           ClockSkew = TimeSpan.FromSeconds(30),//验证Token的时间偏移量
                           ValidateIssuerSigningKey = true,//是否验证安全密钥
                           ValidAudience = AppSettings.JWT.Domain,//访问群体
                           ValidIssuer = AppSettings.JWT.Domain,//颁发者
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())//安全密钥
                       };
                       options.Events = new JwtBearerEvents
                       {   
                           OnChallenge = async context =>
                           {
                               // 跳过默认的处理逻辑，返回下面的模型数据
                               context.HandleResponse();

                               context.Response.ContentType = "application/json;charset=utf-8";
                               context.Response.StatusCode = StatusCodes.Status200OK;

                               var result = new ServiceResult();
                               result.IsFailed("UnAuthorized");
                               await context.Response.WriteAsync(result.ToJson());
                           }
                       };                      
                   });

            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();


            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);
                // 添加自己实现的 MandyBlogExceptionFilter
                options.Filters.Add(typeof(MandyBlogExceptionFilter));
            });

            //后台任务
            //context.Services.AddTransient<IHostedService, HelloWorldJob>()

            //路由
            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });
            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();  
            
            //认证
            app.UseAuthorization();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //使用HSTS的中间件，该中间件添加了严格传输安全头。强制客户端使用https与服务端连接。
            app.UseHsts();

            //默认的跨域配置
            app.UseCors();

            //HTTP请求转HTTPS。
            app.UseHttpsRedirection();
        }
    }
}
