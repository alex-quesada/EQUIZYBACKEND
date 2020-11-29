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
    class AnswerListRepository : Repository<AnswerList>, IAnswerListRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public AnswerListRepository(MyEquizyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<AnswerList>> GetAllAnswerListByQuestionIdAndActivedAsync(int id)
        {
            return await MyEquizyDbContext.AnswerList.Where(m => m.QuizQuestionId == id && m.Status == 1).ToListAsync();
        }

        public async Task<AnswerList> GetAnswerListByIdAsync(int id)
        {
            return await MyEquizyDbContext.AnswerList.SingleOrDefaultAsync(a => a.Id == id);
        }

    }
}
