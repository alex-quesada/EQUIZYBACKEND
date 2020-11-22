using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class ProfessorEvaluationList
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int EvaluationId { get; set; }
        public AppUser User { get; set; }
        public Evaluation Evaluation { get; set; }
        public byte Status { get; set; }
    }
}
