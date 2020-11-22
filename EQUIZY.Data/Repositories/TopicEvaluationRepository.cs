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
    public class TopicEvaluationRepository : Repository<TopicEvaluation>, ITopicEvaluationRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public TopicEvaluationRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<TopicEvaluation>> GetAllTopicEvaluationAsync()
        {
            return await MyEquizyDbContext.TopicsEvaluation.ToListAsync ();
        }

        public async Task<TopicEvaluation> GetTopicEvaluationByIdAsync(int id)
        {
            return await MyEquizyDbContext.TopicsEvaluation.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
