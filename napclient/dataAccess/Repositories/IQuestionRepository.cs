using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionRepository
    {
        Task<Guid> AddAsync(Question question);
        Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(Guid testId);
        Task<Guid> UpdateAsync(Question question);
    }
}
