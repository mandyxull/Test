using Mandy.Blog.Domain;
using Mandy.Blog.Domain.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Mandy.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule),typeof(MandyBlogDomainModule))]
    public class MandyBlogApplicationCachingModule : AbpCachingModule
    {        
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //options.InstanceName //Redis 实例名称
                //options.ConfigurationOptions //Redis 的配置属性
            });
        }
    }
}
