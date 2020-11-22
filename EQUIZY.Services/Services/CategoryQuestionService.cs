using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class CategoryQuestionService : ICategoryQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryQuestionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CategoryQuestion> CreateCategoryQuestion(CategoryQuestion newCategoryQuestion)
        {
            await _unitOfWork.CategoriesQuestion
                .AddAsync(newCategoryQuestion);
            await _unitOfWork.CommitAsync();
            return newCategoryQuestion;
        }

        public async Task DeleteCategoryQuestion(CategoryQuestion categoryQuestion)
        {
            _unitOfWork.CategoriesQuestion.Remove(categoryQuestion);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuesation()
        {
            return await _unitOfWork.CategoriesQuestion.GetAllAsync();
        }

        public async Task<CategoryQuestion> GetCategoryQuestionById(int id)
        {
            return await _unitOfWork.CategoriesQuestion.GetByIdAsync(id);
        }

        public async Task UpdateCategoryQuestion(CategoryQuestion categoryQuestionToUpdate, CategoryQuestion categoryQuestion)
        {
            categoryQuestionToUpdate.Category = categoryQuestion.Category;
            await _unitOfWork.CommitAsync();
        }
    }
}
