using dataAccess.Repositories;
using GraphQL.Types;
using logic;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class UserTestType : ObjectGraphType<UserTest>
    {
        public UserTestType(ITestRepository testRepository, IQuestionLogic questionLogic)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.UserId, type: typeof(IdGraphType));
            Field(t => t.TestId, type: typeof(IdGraphType));
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.Status);
            Field(t => t.Mode);
            Field(t => t.ShuffleSeed);
            Field<TestType>("test",
                resolve: context => testRepository.GetByIdAsync(context.Source.TestId));
            Field<ListGraphType<QuestionType>>("questions",
                resolve: context => questionLogic.GetShuffledQuestionsByTestIdAsync(context.Source.TestId, context.Source.ShuffleSeed));
        }
    }
}
