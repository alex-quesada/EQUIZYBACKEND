using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class TopicQuestionRepository : Repository<TopicQuestion>, ITopicQuestionRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public TopicQuestionRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<TopicQuestion>> GetAllTopicQuestionAsync()
        {
            return await MyEquizyDbContext.TopicsQuestion.ToListAsync();

        }

        public async Task<TopicQuestion> GetTopicQuestionByIdAsync(int id)
        {
            return await MyEquizyDbContext.TopicsQuestion.SingleOrDefaultAsync(a => a.Id == id);

        }
    }
}
