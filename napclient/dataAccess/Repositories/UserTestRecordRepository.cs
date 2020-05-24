using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataAccess.Repositories
{
    public class UserTestRecordRepository : BaseRepository, IUserTestRecordRepository
    {
        public UserTestRecordRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<UserTestRecord> AddAsync(UserTestRecord userTestRecord)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.UserTestRecord.AddAsync(userTestRecord);
                await db.SaveChangesAsync();
                return userTestRecord;
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
