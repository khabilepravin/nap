using dataModel.Repositories;
using models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<User> AddAsync(User user)
        {
            using(var db = base._dbContextFactory.Create())
            {
                user.CreatedAt = DateTime.UtcNow;
                await db.User.AddAsync(user);
                await db.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from u in db.User
                       where u.Id == id
                       select u).FirstOrDefaultAsync<User>();
            }
        }

        public async Task<Guid> UpdateAsync(User user)
        {
            using (var db = base._dbContextFactory.Create())
            {
                user.ModifiedAt = DateTime.UtcNow;
                db.User.Update(user);
                await db.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
