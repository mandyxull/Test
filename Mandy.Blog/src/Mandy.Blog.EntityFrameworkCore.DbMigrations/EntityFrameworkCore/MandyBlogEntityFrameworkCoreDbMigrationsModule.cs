using Mandy.Blog.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Mandy.Blog
{
    [DependsOn(
        typeof(MandyBlogFrameworkCoreModule)
    )]
    public class MandyBlogEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MandyBlogMigrationsDbContext>();
        }
    }
}
