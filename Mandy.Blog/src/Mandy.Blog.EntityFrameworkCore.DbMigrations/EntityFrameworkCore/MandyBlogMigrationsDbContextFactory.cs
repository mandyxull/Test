using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mandy.Blog
{
    public class MandyBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<MandyBlogMigrationsDbContext>
    {
        public MandyBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<MandyBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));
            return new MandyBlogMigrationsDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
