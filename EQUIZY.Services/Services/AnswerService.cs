using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Answer> CreateAnswer(Answer newAnswer)
        {
            await _unitOfWork.Answers
                .AddAsync(newAnswer);
            await _unitOfWork.CommitAsync();
            return newAnswer;
        }

        public async Task DeleteAnswer(Answer answer)
        {
            _unitOfWork.Answers.Remove(answer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAnswers()
        {
            return await _unitOfWork.Answers.GetAllAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionId(int id)
        {
            return await _unitOfWork.Answers.GetAllAnswersByQuestionId(id);
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            return await _unitOfWork.Answers.GetByIdAsync(id);
        }

        public async Task UpdateAnswer(Answer answerToUpdate, Answer answer)
        {
            answerToUpdate.AnswerContent = answer.AnswerContent;
            answerToUpdate.Correct = answer.Correct;
            await _unitOfWork.CommitAsync();
        }
    }
}
