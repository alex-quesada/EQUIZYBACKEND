using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ITypeEvaluationRepository : IRepository<TypeEvaluation>
    {
        Task<IEnumerable<TypeEvaluation>> GetAllTypeEvaluationAsync();
        Task<TypeEvaluation> GetTypeEvaluationByIdAsync(int id);
    }
}
