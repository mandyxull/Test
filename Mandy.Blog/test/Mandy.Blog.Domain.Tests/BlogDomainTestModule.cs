using Mandy.Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mandy.Blog
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreTestModule)
        )]
    public class BlogDomainTestModule : AbpModule
    {

    }
}