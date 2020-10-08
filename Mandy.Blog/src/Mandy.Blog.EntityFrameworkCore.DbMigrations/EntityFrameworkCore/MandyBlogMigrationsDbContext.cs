using Mandy.Blog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace Mandy.Blog
{
    public class MandyBlogMigrationsDbContext : AbpDbContext<MandyBlogMigrationsDbContext>
    {
        public MandyBlogMigrationsDbContext(DbContextOptions<MandyBlogMigrationsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Configure();
        }
    }
}