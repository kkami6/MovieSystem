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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.DateOfBirth)
                .IsRequired();
        }
    }
}
