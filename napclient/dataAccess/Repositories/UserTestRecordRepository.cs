using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace dataAccess.Repositories
{
    public class UserTestRecordRepository : BaseRepository, IUserTestRecordRepository
    {
        public UserTestRecordRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<UserTestRecord> AddAsync(UserTestRecord userTestRecord)
        {
            using (var db = base._dbContextFactory.Create())
            {
                var recordInstance = await (from u in db.UserTestRecord
                                      where u.UserTestId == userTestRecord.UserTestId &&
                                      u.QuestionId == userTestRecord.QuestionId 
                                    select u).FirstOrDefaultAsync<UserTestRecord>();

                if (recordInstance == null)
                {
                    await db.UserTestRecord.AddAsync(userTestRecord);
                    await db.SaveChangesAsync();
                    return userTestRecord;
                }
                else
                {
                    recordInstance.AnswerId = userTestRecord.AnswerId;
                    recordInstance.IsCorrect = userTestRecord.IsCorrect;
                    return await UpdateAsync(recordInstance);
                }
            }
        }

        public async  Task<IEnumerable<UserTestRecord>> GetByUserIdAsync(Guid userId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from u in db.UserTestRecord
                              join ut in db.UserTest
                              on u.UserTestId equals ut.Id
                              where ut.UserId == userId
                              select u).ToListAsync<UserTestRecord>();
            }
        }

        public async Task<UserTestRecord> GetByUserTestAndQuestionId(Guid userTestId, Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from u in db.UserTestRecord                                                          
                              where u.UserTestId == userTestId && u.QuestionId == questionId
                              select u).FirstOrDefaultAsync<UserTestRecord>();
            }
        }
        
        public async Task<IEnumerable<UserTestRecord>> GetByUserTestId(Guid userTestId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from u in db.UserTestRecord
                              where u.UserTestId == userTestId
                              select u).ToListAsync<UserTestRecord>();
            }
        }

        public async Task<UserTestRecord> UpdateAsync(UserTestRecord userTestRecord)
        {
            using (var db = base._dbContextFactory.Create())
            {   
                db.UserTestRecord.Update(userTestRecord);
                await db.SaveChangesAsync();
                return userTestRecord;
            }
        }
    }
}
