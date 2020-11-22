using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IEvaluationRepository :IRepository<Evaluation>
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluationAsync();
        Task<IEnumerable<Evaluation>> GetAllEvaluationsByUserId(Guid userId);
        Task<Evaluation> GetEvaluationByIdAsync(int id);
    }
}
