using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class CategoryQuestion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
