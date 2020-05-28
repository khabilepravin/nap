﻿using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserTestRecordRepository
    {
        Task<UserTestRecord> AddAsync(UserTestRecord userTestRecord);
        Task<IEnumerable<UserTestRecord>> GetByUserIdAsync(Guid userId);
        Task<UserTestRecord> GetByUserTestAndQuestionId(Guid userTestId, Guid questionId);
        Task<UserTestRecord> UpdateAsync(UserTestRecord userTestRecord);
    }
}
