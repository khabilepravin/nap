using models;
using System;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> UpdateAsync(User user);
    }
}
