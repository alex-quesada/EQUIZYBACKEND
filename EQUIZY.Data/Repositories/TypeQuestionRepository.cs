using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class TypeQuestionRepository : Repository<TypeQuestion>, ITypeQuestionRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public TypeQuestionRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<TypeQuestion>> GetAllTypeQuestionAsync()
        {
            return await MyEquizyDbContext.TypesQuestion.ToListAsync();
        }

        public async Task<TypeQuestion> GetTypeQuestionByIdAsync(int id)
        {
            return await MyEquizyDbContext.TypesQuestion.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
