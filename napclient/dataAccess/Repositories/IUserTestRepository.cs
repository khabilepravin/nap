using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRepository
    {
        Task<Guid> AddAsync(UserTest userTest);
        Task<IEnumerable<UserTest>> GetByUserIdAsync(Guid userId);
        Task<Guid> UpdateAsync(UserTest userTest);
    }
}
