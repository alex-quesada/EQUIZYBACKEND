using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class TypeQuestionService : ITypeQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeQuestionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<TypeQuestion> CreateTypeQuestion(TypeQuestion newTypeQuestion)
        {
            await _unitOfWork.TypesQuestion
                .AddAsync(newTypeQuestion);
            await _unitOfWork.CommitAsync();
            return newTypeQuestion;
        }

        public async Task DeleteTypeQuestion(TypeQuestion typeQuestion)
        {
            _unitOfWork.TypesQuestion.Remove(typeQuestion);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TypeQuestion>> GetAllTypeQuestion()
        {
            return await _unitOfWork.TypesQuestion.GetAllAsync();
        }

        public async Task<TypeQuestion> GetTypeQuestionById(int id)
        {
            return await _unitOfWork.TypesQuestion.GetByIdAsync(id);
        }

        public async Task UpdateTypeQuestion(TypeQuestion typeQuestionToUpdate, TypeQuestion typeQuestion)
        {
            typeQuestionToUpdate.Type = typeQuestion.Type;
            await _unitOfWork.CommitAsync();
        }
    }
}
