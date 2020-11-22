using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ICategoryEvaluationService 
    {
        Task<IEnumerable<CategoryEvaluation>> GetAllCategoryEvaluation();
        Task<CategoryEvaluation> GetCategoryEvaluationById(int id);
        Task<CategoryEvaluation> CreateCategoryEvaluation(CategoryEvaluation newCategoryEvaluation);
        Task UpdateCategoryEvaluation(CategoryEvaluation categoryEvaluationToUpdate, CategoryEvaluation categoryEvaluation);
        Task DeleteCategoryEvaluation(CategoryEvaluation categoryEvaluation);
    }
}
