using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IQuizQuestionRepository : IRepository<QuizQuestion>
    {
        Task<IEnumerable<QuizQuestion>> GetAllQuestionsAsync();
        Task<IEnumerable<QuizQuestion>> GetAllQuestionByEvaluationId(int id);
        Task<QuizQuestion> GetQuestionByIdAsync(int id);
    }
}
