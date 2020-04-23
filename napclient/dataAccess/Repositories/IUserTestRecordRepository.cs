using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRecordRepository
    {
        Task<Guid> AddAsync(UserTestRecord userTestRecord);
        Task<IEnumerable<UserTestRecord>> GetByUserIdAsync(Guid userId);
        Task<Guid> UpdateAsync(UserTestRecord userTestRecord);
    }
}
