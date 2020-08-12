using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IFileStorageRepository
    {
        Task<FileStorage> AddAsync(FileStorage fileStorage);
        Task<FileStorage> GetByQuestionAsync(Guid questionId, List<string> fileTypes);
        Task<FileStorage> GetByAnswerAsync(Guid answerId, List<string> fileTypes);
        Task<FileStorage> UpdateAsync(FileStorage fileStorage);
    }
}
