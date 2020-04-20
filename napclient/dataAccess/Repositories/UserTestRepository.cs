using dataModel.Repositories;

namespace dataAccess.Repositories
{
    public class UserTestRepository : BaseRepository, IUserTestRepository
    {
        public UserTestRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
    }
}
