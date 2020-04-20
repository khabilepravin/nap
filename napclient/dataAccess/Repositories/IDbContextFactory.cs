using dataAccess;

namespace dataModel.Repositories
{
    public interface IDbContextFactory
    {
        dataContext Create();
        dataContext CreateNoTracking();
    }
}
