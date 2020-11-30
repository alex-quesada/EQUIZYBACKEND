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
    public class QuizQuestionRepository : Repository<QuizQuestion>, IQuizQuestionRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public QuizQuestionRepository(MyEquizyDbContext context)
    : base(context)
        { }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestionsAsync()
        {
            return await MyEquizyDbContext.QuizQuestions.ToListAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestionByEvaluationId(int id)
        {
            return await MyEquizyDbContext.QuizQuestions.Include(a => a.Answers).Where(y => y.EvaluationId == id).ToListAsync();
        }

        public async Task<QuizQuestion> GetQuestionByIdAsync(int id)
        {
            return await MyEquizyDbContext.QuizQuestions.Include(j => j.Answers).SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
