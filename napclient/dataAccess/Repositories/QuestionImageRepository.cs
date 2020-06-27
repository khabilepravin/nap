using dataModel.Repositories;
using models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class QuestionImageRepository : BaseRepository, IQuestionImageRepository
    {
        public QuestionImageRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
        public async Task<QuestionImage> AddAsync(QuestionImage questionImage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.QuestionImage.AddAsync(questionImage);
                await db.SaveChangesAsync();
                return questionImage;
            }
        }

        public async Task<IEnumerable<QuestionImage>> GetQuestionImage(Guid questionId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await (from q in db.QuestionImage 
                       where q.QuestionId == questionId
                       select q).ToListAsync<QuestionImage>();

            }
        }
    }
}
