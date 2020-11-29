using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAllAnswers();
        Task<IEnumerable<Answer>> GetAllAnswersByEvaluationId(int evaluationId);
        Task<Answer> GetAnswerById(int id);
        Task<Answer> CreateAnswer(Answer newAnswer);
        Task UpdateAnswer(Answer answerToUpdate, Answer answer);
        Task DeleteAnswer(Answer answer);
    }
}
