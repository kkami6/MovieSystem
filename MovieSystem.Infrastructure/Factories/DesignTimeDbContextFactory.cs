using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MovieSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieSystemContext>
    {
        private static IConfiguration Configuration => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("db-design-settings.json")
        .Build();

        public MovieSystemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieSystemContext>();

            var connectionString = Configuration.GetConnectionString("MySqlConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'MySqlConnection' is not set in db-design-settings.json");
            }

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new MovieSystemContext(optionsBuilder.Options);
        }
    }
}
