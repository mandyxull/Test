using Mandy.Blog.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Mandy.Blog
{
    [DependsOn(        
        typeof(AbpIdentityApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(MandyBlogApplicationCachingModule)
        )]
    public class MandyBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MandyBlogApplicationModule>(validate: true);
                options.AddProfile<MandyBlogAutoMapperProfile>(validate: true);
            });
        }
    }
}
