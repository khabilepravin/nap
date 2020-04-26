using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataAccess.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<Question> AddAsync(Question question)
        {
            using (var db = base._dbContextFactory.Create())
            {
                question.CreatedAt = DateTime.UtcNow;
                await db.Question.AddAsync(question);
                await db.SaveChangesAsync();
                return question;
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(Guid testId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from q in db.Question
                        where q.TestId == testId
                        select q).ToListAsync<Question>();
            }
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            using (var db = base._dbContextFactory.Create())
            {
                question.ModifiedAt = DateTime.UtcNow;
                db.Update(question);
                await db.SaveChangesAsync();
                return question;
            }
        }
    }
}
