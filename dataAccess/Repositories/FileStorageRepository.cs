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

        public async Task<FileStorage> UpdateAsync(FileStorage fileStorage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                fileStorage.ModifiedAt = DateTime.UtcNow;
                db.FileStorage.Update(fileStorage);
                await db.SaveChangesAsync();
                return fileStorage;
            }
        }

        public async Task<FileStorage> GetByQuestionAsync(Guid questionId, List<string> fileTypes)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from f in db.FileStorage
                              join q in db.QuestionFile
                              on f.Id equals q.FileId
                              where q.QuestionId == questionId && fileTypes.Contains(f.FileType)
                              select f).FirstOrDefaultAsync<FileStorage>();
            }
        }

        public async Task<FileStorage> GetByAnswerAsync(Guid answerId, List<string> fileTypes)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from f in db.FileStorage
                              join a in db.AnswerFile
                              on f.Id equals a.FileId
                              where a.AnswerId == answerId && fileTypes.Contains(f.FileType)
                              select f).FirstOrDefaultAsync<FileStorage>();
            }
        }
    }
}
