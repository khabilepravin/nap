using dataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class UserTestRepository : BaseRepository, IUserTestRepository
    {
        public UserTestRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<UserTest> AddAsync(UserTest userTest)
        {
            using(var db = base._dbContextFactory.Create())
            {
                userTest.CreatedAt = DateTime.UtcNow;
                await db.AddAsync(userTest);
                await db.SaveChangesAsync();
                return userTest;
            }
        }

        public async Task<IEnumerable<UserTest>> GetByUserIdAsync(Guid userId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from ut in db.UserTest
                       where ut.UserId == userId
                       select ut).ToListAsync<UserTest>();
            }
        }

        public async Task<UserTest> UpdateAsync(UserTest userTest)
        {
            using (var db = base._dbContextFactory.Create())
            {
                userTest.ModifiedAt = DateTime.UtcNow;
                db.Update(userTest);
                await db.SaveChangesAsync();
                return userTest;
            }
        }
    }
}
