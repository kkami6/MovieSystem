using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Infrastructure.Entities;

namespace MovieSystem.Infrastructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movies");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(x => x.ReleaseYear)
                .IsRequired();

            builder.HasMany(x => x.Ratings)
                   .WithOne(r => r.Movie)
                   .HasForeignKey(r => r.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
