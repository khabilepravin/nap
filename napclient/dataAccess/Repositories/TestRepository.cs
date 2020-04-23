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

        public async Task<string> AddAsync(Test test)
        {
            using (var db = base._dbContextFactory.Create())
            {
                test.CreatedAt = DateTime.UtcNow;
                await db.Test.AddAsync(test);
                await db.SaveChangesAsync();
                return test.Id.ToString();
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

        public async Task<string> UpdateAsync(Test test)
        {
            using (var db = base._dbContextFactory.Create())
            {
                test.ModifiedAt = DateTime.UtcNow;
                db.Test.Update(test);
                await db.SaveChangesAsync();
                return test.Id.ToString();
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
    }
}
