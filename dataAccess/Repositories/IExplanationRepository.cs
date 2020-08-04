using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IExplanationRepository
    {
        Task<Explanation> AddAsync(Explanation explanation);
        Task<Explanation> UpdateAsync(Explanation explanation);
        Task<IEnumerable<Explanation>> GetByQuestionId(Guid questionId);
    }
}
