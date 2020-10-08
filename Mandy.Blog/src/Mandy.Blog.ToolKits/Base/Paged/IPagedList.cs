using System;
using System.Collections.Generic;
using System.Text;

namespace Mandy.Blog.ToolKits.Base.Paged
{
    /// <summary>
    /// 分页响应实体接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}
