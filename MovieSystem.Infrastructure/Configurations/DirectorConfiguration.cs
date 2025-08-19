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
    public class DirectorConfiguration : IEntityTypeConfiguration<DirectorEntity>
    {
        public void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Nationality)
                .HasMaxLength(50);

            builder.HasMany(x => x.Movies)
                   .WithOne(m => m.Director)
                   .HasForeignKey(m => m.DirectorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
