using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class AnswerListService : IAnswerListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerListService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AnswerList> CreateAnswerList(AnswerList newAnswerList)
        {
            await _unitOfWork.AnswerList
                .AddAsync(newAnswerList);
            await _unitOfWork.CommitAsync();
            return newAnswerList;
        }

        public async Task DeleteAnswerList(AnswerList answerList)
        {
            var answerListToDelete = await _unitOfWork.AnswerList.SingleOrDefaultAsync(m => m.Id == answerList.Id);
            answerListToDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AnswerList>> GetAllAnswerList()
        {
            return await _unitOfWork.AnswerList.GetAllAsync();
        }

        public async Task<AnswerList> GetAnswerListById(int id)
        {
            return await _unitOfWork.AnswerList.GetAnswerListByIdAsync(id);
        }

        public async Task<IEnumerable<AnswerList>> GetAnswerListByQuestionId(int id)
        {
            return await _unitOfWork.AnswerList.GetAllAnswerListByQuestionIdAndActivedAsync(id);
        }

        public Task UpdateAnswerList(AnswerList answerListToUpdate, AnswerList answerList)
        {
            throw new NotImplementedException();
        }
    }
}
