using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionImageRepository
    {
        Task<QuestionImage> AddAsync(QuestionImage questionImage);
        Task<IEnumerable<QuestionImage>> GetQuestionImage(Guid questionId);
    }
}
