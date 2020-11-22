using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class TopicEvaluationService : ITopicEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicEvaluationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TopicEvaluation> CreateTopicEvaluation(TopicEvaluation newTopicEvaluation)
        {
            await _unitOfWork.TopicsEvaluation
                .AddAsync(newTopicEvaluation);
            await _unitOfWork.CommitAsync();
            return newTopicEvaluation;
        }

        public async Task DeleteTopicEvaluation(TopicEvaluation topicEvaluation)
        {
            _unitOfWork.TopicsEvaluation.Remove(topicEvaluation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TopicEvaluation>> GetAllTopicEvaluation()
        {
            return await _unitOfWork.TopicsEvaluation.GetAllAsync();
        }

        public async Task<TopicEvaluation> GetTopicEvaluationById(int id)
        {
            return await _unitOfWork.TopicsEvaluation.GetByIdAsync(id);
        }

        public async Task UpdateTopicEvaluation(TopicEvaluation topicEvaluationToUpdate, TopicEvaluation topicEvaluation)
        {
            topicEvaluationToUpdate.Topic = topicEvaluation.Topic;
            await _unitOfWork.CommitAsync();
        }
    }
}
