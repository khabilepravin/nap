using dataModel.Repositories;

namespace dataAccess.Repositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
    }
}
