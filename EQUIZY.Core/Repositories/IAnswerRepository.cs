using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task<IEnumerable<Answer>> GetAllAnswersByQuestionId(int id);
        Task<Answer> GetAnswerByIdAsync(int id);
    }
}
