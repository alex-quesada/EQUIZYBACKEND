using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ITopicEvaluationService
    {
        Task<IEnumerable<TopicEvaluation>> GetAllTopicEvaluation();
        Task<TopicEvaluation> GetTopicEvaluationById(int id);
        Task<TopicEvaluation> CreateTopicEvaluation(TopicEvaluation newTopicEvaluation);
        Task UpdateTopicEvaluation(TopicEvaluation topicEvaluationToUpdate, TopicEvaluation topicEvaluation);
        Task DeleteTopicEvaluation(TopicEvaluation topicEvaluation);
    }
}
