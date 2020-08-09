using models;
using System;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IFileStorageRepository
    {
        Task<FileStorage> AddAsync(FileStorage fileStorage);
        Task<FileStorage> GetByQuestionAsync(Guid questionId, string fileExtension=null);
        Task<FileStorage> GetByAnswerAsync(Guid answerId, string fileExtension = null);
        Task<FileStorage> UpdateAsync(FileStorage fileStorage);
    }
}
