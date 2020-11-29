using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    class AnswerListConfiguration : IEntityTypeConfiguration<AnswerList>
    {
        public void Configure(EntityTypeBuilder<AnswerList> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Status).IsRequired();
            builder.HasOne(m => m.QuizQuestion).WithMany().HasForeignKey(m => m.QuizQuestionId);
            builder.HasOne(m => m.Answer).WithMany().HasForeignKey(m => m.AnswerId);

            builder.ToTable("AnswerList");
        }
    }
}
