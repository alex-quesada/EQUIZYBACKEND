using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class TopicQuestionService : ITopicQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicQuestionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TopicQuestion> CreateTopicQuestion(TopicQuestion newTopicQuestion)
        {
            await _unitOfWork.TopicsQuestion
                .AddAsync(newTopicQuestion);
            await _unitOfWork.CommitAsync();
            return newTopicQuestion;
        }

        public async Task DeleteTopicQuestion(TopicQuestion topicQuestion)
        {
            _unitOfWork.TopicsQuestion.Remove(topicQuestion);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TopicQuestion>> GetAllTopicQuestion()
        {
            return await _unitOfWork.TopicsQuestion.GetAllAsync();
        }

        public async Task<TopicQuestion> GetTopicQuestionById(int id)
        {
            return await _unitOfWork.TopicsQuestion.GetByIdAsync(id);

        }

        public async Task UpdateTopicQuestion(TopicQuestion topicQuestionToUpdate, TopicQuestion topicQuestion)
        {
            topicQuestionToUpdate.Topic = topicQuestion.Topic;
            await _unitOfWork.CommitAsync();
        }
    }
}
