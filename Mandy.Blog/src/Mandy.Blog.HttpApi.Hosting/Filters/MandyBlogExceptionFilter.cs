using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mandy.Blog.HttpApi.Hosting.Filters
{
    /// <summary>
    /// 做一些日志记录
    /// </summary>
    public class MandyBlogExceptionFilter: IExceptionFilter
    {
        private readonly ILog _log;
        public MandyBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(MandyBlogExceptionFilter));
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
