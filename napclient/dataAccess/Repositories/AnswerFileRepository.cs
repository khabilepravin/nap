using dataModel.Repositories;
using models;
using System.Threading.Tasks;

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
    }
}
