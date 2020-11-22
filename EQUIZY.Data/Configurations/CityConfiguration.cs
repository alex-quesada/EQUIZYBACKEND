using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(m => m.StateProvince).WithMany(m => m.Cities).HasForeignKey(m => m.StateProvinceId);

            builder.ToTable("Cities");
        }
    }
}
