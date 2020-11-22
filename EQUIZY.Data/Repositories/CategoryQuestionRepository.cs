using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class CategoryQuestionRepository : Repository<CategoryQuestion>, ICategoryQuestionRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public CategoryQuestionRepository(MyEquizyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuestionAsync()
        {
            return await MyEquizyDbContext.CategoriesQuestion.ToListAsync();
        }

        public async Task<CategoryQuestion> GetCategoryQuestionByIdAsync(int id)
        {
            return await MyEquizyDbContext.CategoriesQuestion.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
