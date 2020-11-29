using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class QuestionResource
    {
        public int Id { get; set; }
        public Guid CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }
        public int TypeQuestionId { get; set; }
        public TypeQuestionResource TypeQuestion { get; set; }
        public int CategoryQuestionId { get; set; }
        public CategoryQuestionResource CategoryQuestion { get; set; }
        public int TopicQuestionId { get; set; }
        public TopicQuestionResource TopicQuetion { get; set; }
        public int EvaluationId { get; set; }
        public int TimeToAnswer { get; set; }
        public string Question { get; set; }
        public int Points { get; set; }
        public byte Rating { get; set; }
        public byte Status { get; set; }
        public List<AnswerResource> Answers { get; set; }
    }
}
