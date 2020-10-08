using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Mandy.Blog.Application.Caching
{
    /// <summary>
    /// 缓存基础类
    /// </summary>
    public class MandyBlogApplicationCachingServiceBase: ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }
}
