using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class EvaluationQuestion
    {
        public int Id { get; set; }
        public string CreatedById { get; set; }
        [Required]
        public AppUser CreatedBy { get; set; }
        public int TypeQuestionId { get; set; }
        [Required]
        public TypeQuestion TypeQuestion { get; set; }
        public int CategoryQuestionId { get; set; }
        [Required]
        public CategoryQuestion CategoryQuestion { get; set; }
        public int TopicQuestionId { get; set; }
        [Required]
        public TopicQuestion TopicQuetion { get; set; }
        public int TimeToAnswer { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public int Points { get; set; }
        public byte Rating { get; set; }
        public byte Status { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
