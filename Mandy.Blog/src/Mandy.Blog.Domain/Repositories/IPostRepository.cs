using Mandy.Blog.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Mandy.Blog.Domain.Repositories
{
    /// <summary>
    /// IPostRepository
    /// </summary>
    public interface IPostRepository: IRepository<Post,int>
    {

    }
}
