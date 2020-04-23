using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class TestType : ObjectGraphType<Test>
    {
        public TestType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.Sequence, type: typeof(IntGraphType));
            Field(t => t.Subject);
            Field(t => t.DurationMinutes, type: typeof(IntGraphType));
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.CreatedByUser, type: typeof(IdGraphType));
            Field(t => t.ModifiedByUser, type: typeof(IdGraphType));
        }
    }
}
