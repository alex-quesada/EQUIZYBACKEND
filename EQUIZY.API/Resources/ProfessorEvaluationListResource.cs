using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class ProfessorEvaluationListResource
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int EvaluationId { get; set; }
        public AppUser User { get; set; }
        public Evaluation Evaluation { get; set; }
        public byte Status { get; set; }
    }
}
