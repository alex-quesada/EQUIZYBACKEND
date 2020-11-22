using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    public class ProfessorEvaluationListConfiguration : IEntityTypeConfiguration<ProfessorEvaluationList>
    {
        public void Configure(EntityTypeBuilder<ProfessorEvaluationList> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Status).IsRequired();
            builder.HasOne(m => m.Evaluation).WithMany().HasForeignKey(m => m.EvaluationId);
            builder.HasOne(m => m.User).WithMany().HasForeignKey(m => m.UserId);

            builder.ToTable("ProfessorEvaluationList");
        }
    }
}
