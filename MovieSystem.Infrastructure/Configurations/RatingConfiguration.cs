using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSystem.Infrastructure.Entities;

namespace MovieSystem.Infrastructure.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configuration(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable(nameof(Rating));

            builder.HasKey(x => x.RatingId);

            builder.Property(x => x.Score)
                .IsRequired();
        }
    }
}
