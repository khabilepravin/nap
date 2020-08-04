using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IAnswerRepository
    {
        Task<Answer> AddAsync(Answer answer);
        Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid questionId);
        Task<Answer> UpdateAsync(Answer answer);
        Task<bool> DeleteAsync(Guid answerId);
        
    }
}
