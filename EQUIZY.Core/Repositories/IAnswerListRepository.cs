using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IAnswerListRepository : IRepository<AnswerList>
    {
        Task<IEnumerable<AnswerList>> GetAllAnswerListByQuestionIdAndActivedAsync(int id);
        Task<AnswerList> GetAnswerListByIdAsync(int id);
    }
}
