using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IEvaluationService
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluation();
        Task<IEnumerable<Evaluation>> GetAllEvaluationsByUserId(Guid userId);
        Task<Evaluation> GetEvaluationById(int id);
        Task<Evaluation> CreateEvaluation(Evaluation newEvaluation);
        Task UpdateEvaluation(Evaluation evaluationToUpdate, Evaluation evaluation);
        Task DeleteEvaluation(Evaluation evaluation);
    }
}
