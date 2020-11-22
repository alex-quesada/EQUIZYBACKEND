using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

            builder.Property(m => m.CountryCode).IsRequired().HasMaxLength(50);

            builder.ToTable("Countries");
        }
    }
}
