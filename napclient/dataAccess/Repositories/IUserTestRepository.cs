using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRepository
    {
        Task<string> AddAsync(UserTest userTest);
        Task<IEnumerable<UserTest>> GetByUserIdAsync(string userId);
        Task<string> UpdateAsync(UserTest userTest);
    }
}
