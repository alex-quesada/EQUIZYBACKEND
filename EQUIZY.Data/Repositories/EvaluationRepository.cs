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
    public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public EvaluationRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Evaluation>> GetAllEvaluationAsync()
        {
            return await MyEquizyDbContext.Evaluations.ToListAsync();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(int id)
        {
            return await MyEquizyDbContext.Evaluations.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsByUserId(Guid userId)
        {
            var result = new List<Evaluation>();
            var evalsList = await MyEquizyDbContext.ProfessorEvaluationList.Where(y => y.UserId == userId && y.Status == 1).ToListAsync();
            foreach (var eval in evalsList)
            {
                result.Add(await MyEquizyDbContext.Evaluations.FirstOrDefaultAsync(e => e.Id == eval.Id));
            }
            return result;
        }
    }
}
