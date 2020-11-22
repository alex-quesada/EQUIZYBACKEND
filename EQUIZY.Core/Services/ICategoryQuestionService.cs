using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ICategoryQuestionService
    {
        Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuesation();
        Task<CategoryQuestion> GetCategoryQuestionById(int id);
        Task<CategoryQuestion> CreateCategoryQuestion(CategoryQuestion newCategoryQuestion);
        Task UpdateCategoryQuestion(CategoryQuestion categoryQuestionToUpdate, CategoryQuestion categoryQuestion);
        Task DeleteCategoryQuestion(CategoryQuestion categoryQuestion);
    }
}
