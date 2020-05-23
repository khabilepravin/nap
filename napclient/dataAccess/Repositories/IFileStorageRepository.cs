using models;
using System;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IFileStorageRepository
    {
        Task<FileStorage> AddAsync(FileStorage test);
        Task<FileStorage> GetByQuestionAsync(Guid questionId);
    }
}
