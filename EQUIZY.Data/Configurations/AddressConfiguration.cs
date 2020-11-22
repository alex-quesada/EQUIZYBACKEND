using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.TypeAddressId).IsRequired();

            builder.Property(m => m.Status).IsRequired();

            builder.Property(m => m.AddressOne).IsRequired().HasMaxLength(250);

            builder.Property(m => m.AddressOne).HasMaxLength(250);

            builder.Property(m => m.AddressTwo).HasMaxLength(250);

            builder.Property(m => m.OtherSigns).HasMaxLength(250);

            builder.Property(m => m.ZipCode).IsRequired().HasMaxLength(250);

            builder.HasOne(m => m.City).WithMany().HasForeignKey(m => m.CityId);

            builder.ToTable("Addresses");
        }
    }
}
