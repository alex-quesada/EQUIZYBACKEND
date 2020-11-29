using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class QuestionListResource
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public EvaluationResource Evaluation { get; set; }
        public int QuizQuestionId { get; set; }
        public QuestionResource QuizQuestion { get; set; }
        public byte Status { get; set; }
    }
}
