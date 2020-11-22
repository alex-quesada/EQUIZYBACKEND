using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ITypeEvaluationService
    {
        Task<IEnumerable<TypeEvaluation>> GetAllTypeEvaluation();
        Task<TypeEvaluation> GetTypeEvaluationById(int id);
        Task<TypeEvaluation> CreateTypeEvaluation(TypeEvaluation newTypeEvaluation);
        Task UpdateTypeEvaluation(TypeEvaluation typeEvaluationToUpdate, TypeEvaluation typeEvaluation);
        Task DeleteTypeEvaluation(TypeEvaluation typeEvaluation);
    }
}
