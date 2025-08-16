using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieSystem.Infrastructure.Entities
{
    public class MovieSystemContext : DbContext
    {
        public MovieSystemContext() { }

        public MovieSystemContext(DbContextOptions<MovieSystemContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MovieSystemContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
