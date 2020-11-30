using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public byte Correct { get; set; }
        public int QuizQuestionId { get; set; }
        public byte Status { get; set; }
    }
}
