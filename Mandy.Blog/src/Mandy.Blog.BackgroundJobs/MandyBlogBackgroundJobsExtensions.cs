using Hangfire;
using Mandy.Blog.BackgroundJobs.Jobs.Hangfire;
using System;

namespace Mandy.Blog.BackgroundJobs
{
    public static class MandyBlogBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        { 
            //var job = service.GetService<HangfireTestJob>();

            //RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());
        }
    }
}