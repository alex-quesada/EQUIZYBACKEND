using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IQuestionListRepository : IRepository<QuestionList>
    {
        Task<IEnumerable<QuestionList>> GetAllQuestionListByEvaluationIdAndActivedAsync(int id);
        Task<QuestionList> GetQuestionListByIdAsync(int id);
    }
}
