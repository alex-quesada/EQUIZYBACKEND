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
            var questions = new List<QuizQuestion>();
            var answers = new List<Answer>();
            var evalsList = await MyEquizyDbContext.ProfessorEvaluationList.Where(y => y.UserId == userId && y.Status == 1).ToListAsync();
            foreach (var eval in evalsList)
            {
                var evalToReturn = await MyEquizyDbContext.Evaluations.FirstOrDefaultAsync(e => e.Id == eval.Id);
                var questionList = await MyEquizyDbContext.QuestionList.Where(x => x.EvaluationId == evalToReturn.Id && x.Status == 1).ToListAsync();
                foreach (var ques in questionList)
                {
                    var questionToAdd = await MyEquizyDbContext.QuizQuestions.FirstOrDefaultAsync(y => y.Id == ques.QuizQuestionId);
                    //var answerList = await MyEquizyDbContext.AnswerList.Where(l => l.QuizQuestionId == ques.Id && l.Status == 1).ToListAsync();
                    //foreach (var ans in answerList)
                    //{
                    //    answers.Add(await MyEquizyDbContext.Answers.FirstOrDefaultAsync(p => p.Id == ans.AnswerId));
                    //}
                    //questionToAdd.Answers = answers;
                    questions.Add(questionToAdd);

                }
                evalToReturn.QuizQuestions = questions;
                result.Add(evalToReturn);
            }
            return result;
        }
    }
}
