using dataModel.Repositories;
using models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<Test> AddAsync(Test test)
        {
            using (var db = base._dbContextFactory.Create())
            {
                test.CreatedAt = DateTime.UtcNow;
                await db.Test.AddAsync(test);
                await db.SaveChangesAsync();
                return test;
            }
        }

        public async Task<IEnumerable<Test>> GetBySubjectAsync(string subject)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from t in db.Test
                        where t.Subject == subject
                        select t).ToListAsync<Test>();
            }
        }

        public async Task<Test> UpdateAsync(Test test)
        {
            using (var db = base._dbContextFactory.Create())
            {
                test.ModifiedAt = DateTime.UtcNow;
                db.Test.Update(test);
                await db.SaveChangesAsync();
                return test;
            }
        }

        public async Task<IEnumerable<Test>> GetAll()
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from t in db.Test
                              select t).ToListAsync<Test>();
            }
        }

        public async Task<Test> GetByIdAsync(Guid id)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from t in db.Test
                              where t.Id == id
                              select t).FirstOrDefaultAsync<Test>();
            }
        }

        public async Task<Test> GetByUserTestIdAsync(Guid userTestId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from t in db.Test
                              join ut in db.UserTest 
                              on t.Id equals ut.TestId
                              where ut.Id == userTestId
                              select t).FirstOrDefaultAsync<Test>();
            }
        }

        public async Task<IEnumerable<Test>> GetByTypeAndYear(string testType, string year, string publishedStatus = "published")
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from t in db.Test
                              where t.TestType == testType && 
                              t.Year == year && 
                              t.PublishedStatus == publishedStatus
                              select t).ToListAsync<Test>();
            }
        }
    }
}
