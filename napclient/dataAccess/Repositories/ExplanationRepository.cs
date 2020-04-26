using models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using dataModel.Repositories;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class ExplanationRepository : BaseRepository, IExplanationRepository
    {
        public ExplanationRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }        

        public async Task<Explanation> AddAsync(Explanation explanation)
        {
            using (var db = base._dbContextFactory.Create())
            {
                explanation.CreatedAt = DateTime.UtcNow;
                await db.Explanation.AddAsync(explanation);
                await db.SaveChangesAsync();
                return explanation;
            }
        }

        public async Task<IEnumerable<Explanation>> GetByQuestionId(Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await(from e in db.Explanation
                             where e.QuestionId == questionId
                             select e).ToListAsync<Explanation>();
            }
        }

        public async Task<Explanation> UpdateAsync(Explanation explanation)
        {
            using (var db = base._dbContextFactory.Create())
            {
                explanation.ModifiedAt = DateTime.UtcNow;
                db.Explanation.Update(explanation);
                await db.SaveChangesAsync();
                return explanation;
            }
        }
    }
}
