using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class UserAddressListConfiguration : IEntityTypeConfiguration<UserAddressList>
    {
        public void Configure(EntityTypeBuilder<UserAddressList> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.AddressId).IsRequired();

            builder.Property(m => m.UserId).IsRequired();

            builder.HasOne(m => m.User).WithMany(a => a.AddressList).HasForeignKey(m => m.UserId);

            builder.HasOne(m => m.Address).WithMany(a => a.AddressList).HasForeignKey(m => m.AddressId);

            builder.ToTable("UserAddressList");
        }
    }
}
