using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRepository
    {
        Task<UserTest> AddAsync(UserTest userTest);
        Task<IEnumerable<UserTest>> GetByUserIdAsync(Guid userId);
        Task<UserTest> UpdateAsync(UserTest userTest);
    }
}
