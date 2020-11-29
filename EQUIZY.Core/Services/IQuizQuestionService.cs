using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IQuizQuestionService
    {
        Task<IEnumerable<QuizQuestion>> GetAllQuestions();
        Task<IEnumerable<QuizQuestion>> GetAllQuestionsByEvaluationId(int id);
        Task<QuizQuestion> GetQuestionById(int id);
        Task<QuizQuestion> CreateQuestion(QuizQuestion question);
        Task UpdateQuestion(QuizQuestion questionToUpdate, QuizQuestion question);
        Task DeleteQuestion(QuizQuestion question);
    }
}
