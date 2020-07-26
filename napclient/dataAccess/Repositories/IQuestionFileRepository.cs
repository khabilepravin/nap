using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionFileRepository
    {
        Task<QuestionFile> AddAsync(QuestionFile questionImage);
        Task<IEnumerable<QuestionFile>> GetQuestionImage(Guid questionId);
    }
}
