using dataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public AnswerRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<Answer> AddAsync(Answer answer)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.Answer.AddAsync(answer);
                await db.SaveChangesAsync();
                return answer;
            }
        }

        public async Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await(from a in db.Answer
                             where a.QuestionId == questionId
                             select a).ToListAsync<Answer>();
            }
        }

        public async Task<Answer> UpdateAsync(Answer answer)
        {
            using (var db = base._dbContextFactory.Create())
            {
                
                db.Answer.Update(answer);
                await db.SaveChangesAsync();
                return answer;
            }
        }

        public async Task<bool> DeleteAsync(Guid answerId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                var answer = (from a in db.Answer
                              where a.Id == answerId
                              select a).FirstOrDefault<Answer>();

                db.Remove(answer);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
