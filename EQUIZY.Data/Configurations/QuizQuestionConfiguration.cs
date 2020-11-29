using EQUIZY.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Data.Configurations
{
    class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Status).IsRequired();
            builder.Property(m => m.Points).IsRequired();
            builder.Property(m => m.TimeToAnswer).IsRequired();
            builder.Property(m => m.CreatedById).IsRequired();
            builder.Property(m => m.TypeQuestionId).IsRequired();
            builder.Property(m => m.TopicQuestionId).IsRequired();
            builder.Property(m => m.CategoryQuestionId).IsRequired();
            builder.Property(m => m.Question).IsRequired().HasMaxLength(250);

            builder.ToTable("QuizQuestions");
        }
    }
}
