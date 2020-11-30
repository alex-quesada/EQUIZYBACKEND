using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public Guid CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }
        [Required]
        public int TypeQuestionId { get; set; }
        public TypeQuestion TypeQuestion { get; set; }
        [Required]
        public int CategoryQuestionId { get; set; }
        public CategoryQuestion CategoryQuestion { get; set; }
        [Required]
        public int TopicQuestionId { get; set; }
        public TopicQuestion TopicQuetion { get; set; }
        [Required]
        public int TimeToAnswer { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public int Points { get; set; }
        public int EvaluationId { get; set; }
        public byte Rating { get; set; }
        public byte Status { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
