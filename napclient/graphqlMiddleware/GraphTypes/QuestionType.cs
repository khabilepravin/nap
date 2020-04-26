using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class QuestionType : ObjectGraphType<Question>
    {
        public QuestionType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.TestId, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.QuestionType);
            Field(t => t.Sequence, type: typeof(IntGraphType));
            Field(t => t.ImageUrl);
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.CreatedByUser, type: typeof(IdGraphType));
            Field(t => t.ModifiedByUser, type: typeof(IdGraphType));
            Field(t => t.Status);
        }
    }
}
