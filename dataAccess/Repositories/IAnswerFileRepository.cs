using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IAnswerFileRepository
    {
        Task<AnswerFile> AddAsync(AnswerFile answerImage);
        Task<IEnumerable<AnswerFile>> GetAnswerFiles(Guid answerId, IEnumerable<string> fileTypes);
    }
}
