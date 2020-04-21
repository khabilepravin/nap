using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRecordRepository
    {
        Task<string> AddAsync(UserTestRecord userTestRecord);
        Task<IEnumerable<UserTestRecord>> GetByUserIdAsync(string userId);
        Task<string> UpdateAsync(UserTestRecord userTestRecord);
    }
}
