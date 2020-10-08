using Mandy.Blog.Domain.Blog;
using Mandy.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Mandy.Blog.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// CategoryRepository
    /// </summary>
    public class CategoryRepository : EfCoreRepository<MandyBlogDbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<MandyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
