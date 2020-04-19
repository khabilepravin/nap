namespace dataAccess.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
    }
}
