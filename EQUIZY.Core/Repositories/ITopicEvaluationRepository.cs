using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ITopicEvaluationRepository : IRepository<TopicEvaluation>
    {
        Task<IEnumerable<TopicEvaluation>> GetAllTopicEvaluationAsync();
        Task<TopicEvaluation> GetTopicEvaluationByIdAsync(int id);
    }
}
