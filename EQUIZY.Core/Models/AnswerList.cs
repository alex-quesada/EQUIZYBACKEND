using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class AnswerList
    {
        public int Id { get; set; }
        public int QuizQuestionId { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public byte Status { get; set; }
    }
}
