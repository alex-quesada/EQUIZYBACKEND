using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class TypeEvaluationRepository : Repository<TypeEvaluation>, ITypeEvaluationRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public TypeEvaluationRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<TypeEvaluation>> GetAllTypeEvaluationAsync()
        {
            return await MyEquizyDbContext.TypesEvaluation.ToListAsync();
        }

        public async Task<TypeEvaluation> GetTypeEvaluationByIdAsync(int id)
        {
            return await MyEquizyDbContext.TypesEvaluation.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
