using dataAccess.Repositories;
using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class TestType : ObjectGraphType<Test>
    {
        public TestType(IQuestionRepository questionRepository)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.Sequence);
            Field(t => t.Subject);
            Field(t => t.DurationMinutes);
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.CreatedByUser, type: typeof(IdGraphType));
            Field(t => t.ModifiedByUser, type: typeof(IdGraphType));
            Field(t => t.Status);
            Field(t => t.DifficultyLevel);
            Field(t => t.Year);
            Field(t => t.TestType);
            Field(t => t.PublishedStatus);
            Field<ListGraphType<QuestionType>>("questions",
                resolve: context => questionRepository.GetQuestionsByTestIdAsync(context.Source.Id));
        }
    }
}
