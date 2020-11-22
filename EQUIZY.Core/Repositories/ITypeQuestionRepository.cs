using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ITypeQuestionRepository : IRepository<TypeQuestion>
    {
        Task<IEnumerable<TypeQuestion>> GetAllTypeQuestionAsync();
        Task<TypeQuestion> GetTypeQuestionByIdAsync(int id);
    }
}
