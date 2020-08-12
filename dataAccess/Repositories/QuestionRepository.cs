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
            using (var db = base._dbContextFactory.Create())
            {

                return await (from q in db.Question
                              where q.TestId == testId
                              select q).ToListAsync<Question>();
            }
        }


        public async Task<Question> GetQuestionById(Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from q in db.Question
                              where q.Id == questionId
                              select q).FirstOrDefaultAsync<Question>();
            }
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            using (var db = base._dbContextFactory.Create())
            {
                question.ModifiedAt = DateTime.UtcNow;
                db.Question.Update(question);
                await db.SaveChangesAsync();
                return question;
            }
        }

        public async Task<bool> DeleteAsync(Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                var question = (from q in db.Question
                                where q.Id == questionId
                                select q).FirstOrDefault<Question>();

                if (question != null)
                {
                    db.Question.Remove(question);
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception($"No question found with id {questionId}");
                }
            }
        }
    }
}
