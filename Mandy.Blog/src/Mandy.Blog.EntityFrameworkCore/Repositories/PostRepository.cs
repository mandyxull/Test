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
    /// PostRepository
    /// </summary>
    public class PostRepository: EfCoreRepository<MandyBlogDbContext,Post,int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<MandyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
