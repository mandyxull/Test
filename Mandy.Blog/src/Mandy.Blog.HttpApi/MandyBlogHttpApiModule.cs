using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Mandy.Blog
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(MandyBlogApplicationModule)
        )]
    public class MandyBlogHttpApiModule : AbpModule
    {
        //public override void ConfigureServices(ServiceConfigurationContext context)
        //{
            
        //}
    }
}
