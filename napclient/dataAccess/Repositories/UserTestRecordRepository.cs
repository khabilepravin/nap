using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class UserTestRecordRepository : BaseRepository, IUserTestRecordRepository
    {
        public UserTestRecordRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<Guid> AddAsync(UserTestRecord userTestRecord)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.UserTestRecord.AddAsync(userTestRecord);
                await db.SaveChangesAsync();
                return userTestRecord.Id;
            }
        }

        public  Task<IEnumerable<UserTestRecord>> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
            //using (var db = base._dbContextFactory.Create())
            //{
            //    return await(from u in db.UserTestRecord join 

            //                 where u. == id
            //                 select u).FirstOrDefaultAsync<User>();
            //}
        }

        public async Task<Guid> UpdateAsync(UserTestRecord userTestRecord)
        {
            using (var db = base._dbContextFactory.Create())
            {   
                db.UserTestRecord.Update(userTestRecord);
                await db.SaveChangesAsync();
                return userTestRecord.Id;
            }
        }
    }
}
