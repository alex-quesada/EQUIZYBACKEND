using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class EvaluationResource
    {
        public int Id { get; set; }
        public Guid CreatedById { get; set; }
        [Required]
        public int TypeEvaluationId { get; set; }
        [Required]
        public int CategoryEvaluationId { get; set; }
        [Required]
        public int TopicEvaluationId { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(255)]
        public string Rules { get; set; }
        public List<QuestionResource> QuizQuestions { get; set; }
        public byte Rating { get; set; }
    }
}
