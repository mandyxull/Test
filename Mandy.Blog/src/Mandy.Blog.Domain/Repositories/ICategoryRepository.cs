using Mandy.Blog.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Mandy.Blog.Domain.Repositories
{
    /// <summary>
    /// ICategoryRepository
    /// </summary>
    public interface ICategoryRepository: IRepository<Category, int>
    {

    }
}
