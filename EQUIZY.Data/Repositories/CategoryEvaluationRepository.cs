using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using EQUIZY.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class CategoryEvaluationRepository : Repository<CategoryEvaluation>, ICategoryEvaluationRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public CategoryEvaluationRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<CategoryEvaluation>> GetAllCategoryEvaluationAsync()
        {
            return await MyEquizyDbContext.CategoriesEvaluation.ToListAsync();
        }

        public async Task<CategoryEvaluation> GetCategoryEvaluationByIdAsync(int id)
        {
            return await MyEquizyDbContext.CategoriesEvaluation.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
