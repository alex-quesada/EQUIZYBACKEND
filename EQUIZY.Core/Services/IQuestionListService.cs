using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IQuestionListService
    {
        Task<IEnumerable<QuestionList>> GetAllQuestionList();
        Task<QuestionList> GetQuestionListById(int id);
        Task<IEnumerable<QuestionList>> GetQuestionListByEvaluationId(int id);
        Task<QuestionList> CreateQuestionList(QuestionList newQuestionList);
        Task UpdateQuestionList(QuestionList questionListToUpdate, QuestionList questionList);
        Task DeleteQuestionList(QuestionList questionList);
    }
}
