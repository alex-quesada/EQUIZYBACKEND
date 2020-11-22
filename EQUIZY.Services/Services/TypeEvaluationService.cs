using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class TypeEvaluationService : ITypeEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeEvaluationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TypeEvaluation> CreateTypeEvaluation(TypeEvaluation newTypeEvaluation)
        {
            await _unitOfWork.TypesEvaluation
                .AddAsync(newTypeEvaluation);
            await _unitOfWork.CommitAsync();
            return newTypeEvaluation;
        }

        public async Task DeleteTypeEvaluation(TypeEvaluation typeEvaluation)
        {
            _unitOfWork.TypesEvaluation.Remove(typeEvaluation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TypeEvaluation>> GetAllTypeEvaluation()
        {
            return await _unitOfWork.TypesEvaluation.GetAllAsync();
        }

        public async Task<TypeEvaluation> GetTypeEvaluationById(int id)
        {
            return await _unitOfWork.TypesEvaluation.GetByIdAsync(id);
        }

        public async Task UpdateTypeEvaluation(TypeEvaluation typeEvaluationToUpdate, TypeEvaluation typeEvaluation)
        {
            typeEvaluationToUpdate.Type = typeEvaluation.Type;
            await _unitOfWork.CommitAsync();
        }
    }
}
