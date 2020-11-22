using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ITopicQuestionRepository : IRepository<TopicQuestion>
    {
        Task<IEnumerable<TopicQuestion>> GetAllTopicQuestionAsync();
        Task<TopicQuestion> GetTopicQuestionByIdAsync(int id);
    }
}
