using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> UpdateAsync(User user);
        Task<User> GetBySocialId(string socialId);
        Task<User> GetByEmailId(string email);
        Task<IEnumerable<User>> GetByParentId(Guid id);
    }
}
