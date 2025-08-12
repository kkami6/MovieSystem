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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));

            builder.HasKey(x => x.MovieId);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired();

            builder.Property(x => x.ReleaseDate)
                .IsRequired();
        }
    }
}
