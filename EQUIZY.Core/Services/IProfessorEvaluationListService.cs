using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IProfessorProfessorEvaluationListService
    {
        Task<IEnumerable<ProfessorEvaluationList>> GetAllProfessorEvaluationList();
        Task<ProfessorEvaluationList> GetProfessorEvaluationListById(int id);
        Task<ProfessorEvaluationList> GetProfessorEvaluationListByEvaluationId(int id);
        Task<ProfessorEvaluationList> CreateProfessorEvaluationList(ProfessorEvaluationList newProfessorEvaluationList);
        Task UpdateProfessorEvaluationList(ProfessorEvaluationList ProfessorEvaluationListToUpdate, ProfessorEvaluationList ProfessorEvaluationList);
        Task DeleteProfessorEvaluationList(ProfessorEvaluationList ProfessorEvaluationList);
    }
}
