using dataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class FileStorageRepository : BaseRepository, IFileStorageRepository
    {
        public FileStorageRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
        public async Task<FileStorage> AddAsync(FileStorage fileStorage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                fileStorage.CreatedAt = DateTime.UtcNow;
                await db.FileStorage.AddAsync(fileStorage);
                await db.SaveChangesAsync();
                return fileStorage;
            }
        }

        public async Task<FileStorage> GetByQuestionAsync(Guid questionId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from f in db.FileStorage
                              join q in db.QuestionImage
                              on f.Id equals q.FileId
                              where q.QuestionId == questionId
                              select f).FirstOrDefaultAsync<FileStorage>();
            }
        }
    }
}
