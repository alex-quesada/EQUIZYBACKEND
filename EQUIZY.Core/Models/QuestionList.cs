using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class QuestionList
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
        public int QuizQuestionId { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
        public byte Status { get; set; }
    }
}
