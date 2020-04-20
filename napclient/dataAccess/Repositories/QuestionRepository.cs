using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<string> AddAsync(Question question)
        {
            using (var db = base._dbContextFactory.Create())
            {
                question.CreatedAt = DateTime.UtcNow;
                await db.Question.AddAsync(question);
                await db.SaveChangesAsync();
                return question.Id;
            }
        }

        public Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(string testId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> UpdateAsync(Question question)
        {
            using (var db = base._dbContextFactory.Create())
            {
                question.ModifiedAt = DateTime.UtcNow;
                db.Update(question);
                await db.SaveChangesAsync();
                return question.Id;
            }
        }
    }
}
