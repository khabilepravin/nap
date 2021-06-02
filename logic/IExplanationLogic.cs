using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace logic
{
    public interface IExplanationLogic
    {
        Task<Explanation> AddAsync(Explanation explanation);
        Task<Explanation> UpdateAsync(Explanation explanation);
        Task<IEnumerable<Explanation>> GetByQuestionId(Guid questionId);
    }
}
