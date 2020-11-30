using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizQuestionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<QuizQuestion> CreateQuestion(QuizQuestion question)
        {
            await _unitOfWork.QuizQuestions
                .AddAsync(question);
            await _unitOfWork.CommitAsync();
            return question;
        }

        public async Task DeleteQuestion(QuizQuestion question)
        {
            var questionToDelete = await _unitOfWork.QuizQuestions.SingleOrDefaultAsync(m => m.Id == question.Id);
            questionToDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestions()
        {
            return await _unitOfWork.QuizQuestions.GetAllAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestionsByEvaluationId(int id)
        {
            return await _unitOfWork.QuizQuestions.GetAllQuestionByEvaluationId(id);
        }

        public async Task<QuizQuestion> GetQuestionById(int id)
        {
            return await _unitOfWork.QuizQuestions.GetQuestionByIdAsync(id);
        }

        public async Task UpdateQuestion(QuizQuestion questionToUpdate, QuizQuestion question)
        {
            questionToUpdate.Question = question.Question;
            questionToUpdate.Points = question.Points;
            questionToUpdate.TimeToAnswer = question.TimeToAnswer;
            questionToUpdate.TopicQuestionId = question.TopicQuestionId;
            questionToUpdate.CategoryQuestionId = question.CategoryQuestionId;
            questionToUpdate.TypeQuestionId = question.TypeQuestionId;
            await _unitOfWork.CommitAsync();
        }
    }
}
