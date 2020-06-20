using dataModel.Repositories;
using models;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public class AnswerImageRepository : BaseRepository, IAnswerImageRepository
    {
        public AnswerImageRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<AnswerImage> AddAsync(AnswerImage answerImage)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.AnswerImage.AddAsync(answerImage);
                await db.SaveChangesAsync();
                return answerImage;
            }
        }
    }
}
