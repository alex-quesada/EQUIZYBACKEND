using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class TypeAddressConfiguration : IEntityTypeConfiguration<TypeAddress>
    {
        public void Configure(EntityTypeBuilder<TypeAddress> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.Type).IsRequired().HasMaxLength(50);

            builder.ToTable("TypesAddress");
        }
    }
}
