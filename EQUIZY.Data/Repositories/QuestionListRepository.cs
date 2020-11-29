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
    public class QuestionListRepository : Repository<QuestionList>, IQuestionListRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public QuestionListRepository(MyEquizyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<QuestionList>> GetAllQuestionListByEvaluationIdAndActivedAsync(int id)
        {
            return await MyEquizyDbContext.QuestionList.Where(m => m.EvaluationId == id && m.Status == 1).ToListAsync();
        }

        public async Task<QuestionList> GetQuestionListByIdAsync(int id)
        {
            return await MyEquizyDbContext.QuestionList.SingleOrDefaultAsync(a => a.Id == id);

        }
    }
}
