using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Mandy.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class MandyBlogDomainModule:AbpModule
    {

    }
}
