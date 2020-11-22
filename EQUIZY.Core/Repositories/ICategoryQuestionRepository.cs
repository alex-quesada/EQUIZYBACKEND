using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ICategoryQuestionRepository : IRepository<CategoryQuestion>
    {
        Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuestionAsync();
        Task<CategoryQuestion> GetCategoryQuestionByIdAsync(int id);
    }
}
