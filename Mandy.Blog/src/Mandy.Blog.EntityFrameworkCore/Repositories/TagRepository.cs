using Mandy.Blog.Domain.Blog;
using Mandy.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Mandy.Blog.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// TagRepository
    /// </summary>
    public class TagRepository : EfCoreRepository<MandyBlogDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<MandyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Tag> tags)
        {
            await DbContext.Set<Tag>().AddRangeAsync(tags);
            await DbContext.SaveChangesAsync();
        }
    }
}