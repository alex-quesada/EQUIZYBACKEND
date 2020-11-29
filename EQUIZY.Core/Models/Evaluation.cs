using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public Guid CreatedById { get; set; }
        [Required]
        public AppUser CreatedBy { get; set; }
        public int TypeEvaluationId { get; set; }
        [Required]
        public TypeEvaluation TypeEvaluation { get; set; }
        public int CategoryEvaluationId { get; set; }
        [Required]
        public CategoryEvaluation CategoryEvaluation { get; set; }
        public int TopicEvaluationId { get; set; }
        [Required]
        public TopicEvaluation TopicEvaluation { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(255)]
        public string Rules { get; set; }
        public byte Rating { get; set; }
        public byte Status { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }
    }
}
