using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    class QuestionListService : IQuestionListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionListService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<QuestionList> CreateQuestionList(QuestionList newQuestionList)
        {
            await _unitOfWork.QuestionList
                .AddAsync(newQuestionList);
            await _unitOfWork.CommitAsync();
            return newQuestionList;
        }

        public async Task DeleteQuestionList(QuestionList questionList)
        {
            var questionListToDelete = await _unitOfWork.QuestionList.SingleOrDefaultAsync(m => m.Id == questionList.Id);
            questionListToDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<QuestionList>> GetAllQuestionList()
        {
            return await _unitOfWork.QuestionList.GetAllAsync();
        }

        public async Task<IEnumerable<QuestionList>> GetQuestionListByEvaluationId(int id)
        {
            return await _unitOfWork.QuestionList.GetAllQuestionListByEvaluationIdAndActivedAsync(id);
        }

        public async Task<QuestionList> GetQuestionListById(int id)
        {
            return await _unitOfWork.QuestionList.GetQuestionListByIdAsync(id);
        }

        public Task UpdateQuestionList(QuestionList questionListToUpdate, QuestionList questionList)
        {
            throw new NotImplementedException();
        }
    }
}
