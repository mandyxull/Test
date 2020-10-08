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
    /// PostTagRepository
    /// </summary>
    public class FriendLinkRepository : EfCoreRepository<MandyBlogDbContext, FriendLink, int>, IFriendLinkRepository
    {
        public FriendLinkRepository(IDbContextProvider<MandyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
