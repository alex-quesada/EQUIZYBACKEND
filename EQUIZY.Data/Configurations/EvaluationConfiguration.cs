using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Status).IsRequired();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(250);
            builder.Property(m => m.Rules).IsRequired().HasMaxLength(250);
            builder.HasOne(m => m.TopicEvaluation).WithMany(a => a.Evaluations).HasForeignKey(m => m.TopicEvaluationId);
            builder.HasOne(m => m.TypeEvaluation).WithMany(a => a.Evaluations).HasForeignKey(m => m.TypeEvaluationId);
            builder.HasOne(m => m.CategoryEvaluation).WithMany(a => a.Evaluations).HasForeignKey(m => m.CategoryEvaluationId);
            builder.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.CreatedById);

            builder.ToTable("Evaluations");
        }
    }
}
