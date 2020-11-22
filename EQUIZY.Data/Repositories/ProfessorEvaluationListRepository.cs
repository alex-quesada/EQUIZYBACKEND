using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    class ProfessorEvaluationListRepository : Repository<ProfessorEvaluationList>, IProfessorEvaluationListRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public ProfessorEvaluationListRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<ProfessorEvaluationList>> GetAllProfessorEvaluationListByUserIAndActivedAsync(Guid id)
        {
            return await MyEquizyDbContext.ProfessorEvaluationList.Where(m => m.UserId == id && m.Status == 1).ToListAsync();
        }
        public async Task<ProfessorEvaluationList> GetProfessorEvaluationListByIdAsync(int id)
        {
            return await MyEquizyDbContext.ProfessorEvaluationList.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ProfessorEvaluationList> GetProfessorEvaluationListByEvaluationIdAsync(int id)
        {
            return await MyEquizyDbContext.ProfessorEvaluationList.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
