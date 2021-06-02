using dataAccess.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace logic
{
    public class ExplanationLogic : IExplanationLogic
    {
        private readonly IExplanationRepository _explanationRepository;
        public ExplanationLogic(IExplanationRepository explanationRepository)
        {
            _explanationRepository = explanationRepository;
        }

        public async Task<Explanation> AddAsync(Explanation explanation)
        {
            return await _explanationRepository.AddAsync(explanation);
        }

        public async Task<IEnumerable<Explanation>> GetByQuestionId(Guid questionId)
        {
            var results = await _explanationRepository.GetByQuestionId(questionId);

            return results;
        }

        public async Task<Explanation> UpdateAsync(Explanation explanation)
        {
            return await _explanationRepository.UpdateAsync(explanation);
        }
    }
}
