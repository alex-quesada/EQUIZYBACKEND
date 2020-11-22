using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class CategoryEvaluation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}
