﻿using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface ITestRepository
    {
        Task<Test> AddAsync(Test test);
        Task<IEnumerable<Test>> GetBySubjectAsync(string subject);
        Task<Test> GetByIdAsync(Guid id);
        Task<Test> GetByUserTestIdAsync(Guid userTestId);

        Task<Test> UpdateAsync(Test test);
        Task<IEnumerable<Test>> GetAll();
        Task<IEnumerable<Test>> GetByTypeAndYear(string testType, string year, string publishedStatus = "published");
    }
}
