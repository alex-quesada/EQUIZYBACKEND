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
    class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public AnswerRepository(MyEquizyDbContext context)
    : base(context)
        { }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            return await MyEquizyDbContext.Answers.ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionId(int id)
        {
            return await MyEquizyDbContext.Answers.Where(j => j.QuizQuestionId == id).ToListAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await MyEquizyDbContext.Answers.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
