using dataModel.Repositories;
using models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class QuestionFileRepository : BaseRepository, IQuestionFileRepository
    {
        public QuestionFileRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
        public async Task<QuestionFile> AddAsync(QuestionFile questionImage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.QuestionFile.AddAsync(questionImage);
                await db.SaveChangesAsync();
                return questionImage;
            }
        }

        public async Task<IEnumerable<QuestionFile>> GetQuestionImage(Guid questionId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from q in db.QuestionFile 
                       where q.QuestionId == questionId
                       select q).ToListAsync<QuestionFile>();

            }
        }
    }
}
