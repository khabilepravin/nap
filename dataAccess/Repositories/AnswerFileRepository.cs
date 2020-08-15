using dataModel.Repositories;
using models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class AnswerFileRepository : BaseRepository, IAnswerFileRepository
    {
        public AnswerFileRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<AnswerFile> AddAsync(AnswerFile answerImage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.AnswerFile.AddAsync(answerImage);
                await db.SaveChangesAsync();
                return answerImage;
            }
        }     

        public async Task<IEnumerable<AnswerFile>> GetAnswerFiles(Guid answerId, IEnumerable<string> fileTypes)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from a in db.AnswerFile
                                  join fl in db.FileStorage
                                  on a.FileId equals fl.Id
                                  where a.AnswerId == answerId && fileTypes.Contains(fl.FileType)
                                  select a).ToListAsync<AnswerFile>();
            }
        }
    }
}
