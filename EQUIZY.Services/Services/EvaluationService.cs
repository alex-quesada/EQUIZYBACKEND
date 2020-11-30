using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Evaluation> CreateEvaluation(Evaluation newEvaluation)
        {
            await _unitOfWork.Evaluations
                .AddAsync(newEvaluation);
            await _unitOfWork.CommitAsync();
            return newEvaluation;
        }

        public async Task DeleteEvaluation(Evaluation evaluation)
        {
            var evaluationtoDelete = await _unitOfWork.Evaluations.SingleOrDefaultAsync(m => m.Id == evaluation.Id);
            evaluationtoDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluation()
        {
            return await _unitOfWork.Evaluations.GetAllAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsByUserId(Guid userId)
        {
            return await _unitOfWork.Evaluations.GetAllEvaluationsByUserId(userId);
        }

        public async Task<Evaluation> GetEvaluationById(int id)
        {
            return await _unitOfWork.Evaluations.GetEvaluationByIdAsync(id);
        }

        public async Task UpdateEvaluation(Evaluation evaluationToUpdate, Evaluation evaluation)
        {
            evaluationToUpdate.Name = evaluation.Name;
            evaluationToUpdate.Rules = evaluation.Rules;
            evaluationToUpdate.Description = evaluation.Description;
            evaluationToUpdate.TopicEvaluation = evaluation.TopicEvaluation;
            evaluationToUpdate.TopicEvaluationId = evaluation.TopicEvaluationId;
            evaluationToUpdate.TypeEvaluation = evaluation.TypeEvaluation;
            evaluationToUpdate.TypeEvaluationId = evaluation.TypeEvaluationId;
            evaluationToUpdate.CategoryEvaluation = evaluation.CategoryEvaluation;
            evaluationToUpdate.CategoryEvaluationId = evaluation.CategoryEvaluationId;
            await _unitOfWork.CommitAsync();
        }
    }
}
