using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> AddAsync(Question question);
        Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(Guid testId);
        Task<Question> UpdateAsync(Question question);
        Task<Question> GetQuestionById(Guid questionId);
    }
}
