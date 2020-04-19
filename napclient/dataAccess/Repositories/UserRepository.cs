namespace dataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
    }
}
