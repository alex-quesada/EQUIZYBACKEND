using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class ProfessorEvaluationListService : IProfessorProfessorEvaluationListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorEvaluationListService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ProfessorEvaluationList> CreateProfessorEvaluationList(ProfessorEvaluationList newProfessorEvaluationList)
        {
            await _unitOfWork.ProfessorEvaluationList
                .AddAsync(newProfessorEvaluationList);
            await _unitOfWork.CommitAsync();
            return newProfessorEvaluationList;
        }

        public async Task DeleteProfessorEvaluationList(ProfessorEvaluationList ProfessorEvaluationList)
        {
            var evaluationtoDelete = await _unitOfWork.ProfessorEvaluationList.SingleOrDefaultAsync(m => m.Id == ProfessorEvaluationList.Id);
            evaluationtoDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProfessorEvaluationList>> GetAllProfessorEvaluationList()
        {
            return await _unitOfWork.ProfessorEvaluationList.GetAllAsync();
        }

        public async Task<ProfessorEvaluationList> GetProfessorEvaluationListByEvaluationId(int id)
        {
            return await _unitOfWork.ProfessorEvaluationList.GetProfessorEvaluationListByEvaluationIdAsync(id);
        }

        public async Task<ProfessorEvaluationList> GetProfessorEvaluationListById(int id)
        {
            return await _unitOfWork.ProfessorEvaluationList.GetByIdAsync(id);
        }

        public async Task UpdateProfessorEvaluationList(ProfessorEvaluationList ProfessorEvaluationListToUpdate, ProfessorEvaluationList ProfessorEvaluationList)
        {
            ProfessorEvaluationListToUpdate.Status = ProfessorEvaluationList.Status;
            ProfessorEvaluationListToUpdate.User = ProfessorEvaluationList.User;
            ProfessorEvaluationListToUpdate.UserId = ProfessorEvaluationList.UserId;
            ProfessorEvaluationListToUpdate.Evaluation = ProfessorEvaluationList.Evaluation;
            ProfessorEvaluationListToUpdate.EvaluationId = ProfessorEvaluationList.EvaluationId;
            await _unitOfWork.CommitAsync();
        }
    }
}
