using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ITopicQuestionService
    {
        Task<IEnumerable<TopicQuestion>> GetAllTopicQuestion();
        Task<TopicQuestion> GetTopicQuestionById(int id);
        Task<TopicQuestion> CreateTopicQuestion(TopicQuestion newTopicQuestion);
        Task UpdateTopicQuestion(TopicQuestion topicQuestionToUpdate, TopicQuestion topicQuestion);
        Task DeleteTopicQuestion(TopicQuestion topicQuestion);
    }
}
