using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IProfessorEvaluationListRepository : IRepository<ProfessorEvaluationList>
    {
        Task<IEnumerable<ProfessorEvaluationList>> GetAllProfessorEvaluationListByUserIAndActivedAsync(Guid id);
        Task<ProfessorEvaluationList> GetProfessorEvaluationListByIdAsync(int id);
        Task<ProfessorEvaluationList> GetProfessorEvaluationListByEvaluationIdAsync(int id);
    }
}