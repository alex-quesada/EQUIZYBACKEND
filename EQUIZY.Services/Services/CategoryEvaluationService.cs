using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class CategoryEvaluationService : ICategoryEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryEvaluationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CategoryEvaluation> CreateCategoryEvaluation(CategoryEvaluation newCategoryEvaluation)
        {
            await _unitOfWork.CategoriesEvaluation
                .AddAsync(newCategoryEvaluation);
            await _unitOfWork.CommitAsync();
            return newCategoryEvaluation;
        }

        public async Task DeleteCategoryEvaluation(CategoryEvaluation categoryEvaluation)
        {
            _unitOfWork.CategoriesEvaluation.Remove(categoryEvaluation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CategoryEvaluation>> GetAllCategoryEvaluation()
        {
            return await _unitOfWork.CategoriesEvaluation.GetAllAsync();
        }

        public async Task<CategoryEvaluation> GetCategoryEvaluationById(int id)
        {
            return await _unitOfWork.CategoriesEvaluation.GetByIdAsync(id);
        }

        public async Task UpdateCategoryEvaluation(CategoryEvaluation categoryEvaluationToUpdate, CategoryEvaluation categoryEvaluation)
        {
            categoryEvaluationToUpdate.Category = categoryEvaluation.Category;
            await _unitOfWork.CommitAsync();
        }
    }
}
