using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class TypeEvaluation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}
