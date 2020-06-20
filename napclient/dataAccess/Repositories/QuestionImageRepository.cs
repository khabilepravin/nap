using dataModel.Repositories;
using models;
using System;
using System.Threading.Tasks;

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
    }
}
