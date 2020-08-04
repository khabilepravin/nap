using dataModel.Repositories;

namespace dataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly IDbContextFactory _dbContextFactory;

        public BaseRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
