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
            var answers = new List<Answer>();
            var answerList = await MyEquizyDbContext.AnswerList.Where(x => x.QuizQuestionId == id && x.Status == 1).ToListAsync();
            foreach (var ans in answerList)
            {
                answers.Add(await MyEquizyDbContext.Answers.SingleOrDefaultAsync(y => y.Id == ans.AnswerId));
            }
            return answers;
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await MyEquizyDbContext.Answers.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
