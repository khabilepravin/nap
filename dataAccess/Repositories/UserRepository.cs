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
                var existingUser = await (from u in db.User
                                    where u.Email == user.Email
                                    select u).FirstOrDefaultAsync<User>();

                if (existingUser == null)
                {
                    user.CreatedAt = DateTime.UtcNow;
                    await db.User.AddAsync(user);
                    await db.SaveChangesAsync();
                    return user;
                }
                else
                {
                    return null;
                }
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

        public async Task<User> GetBySocialId(string socialId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from u in db.User
                              where u.SocialLoginId == socialId
                              select u).FirstOrDefaultAsync<User>();
            }
        }
    }
}
