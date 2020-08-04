using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class ExplanationType : ObjectGraphType<Explanation>
    {
        public ExplanationType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.QuestionId, type: typeof(IdGraphType));
            Field(t => t.TextExplanation);
            Field(t => t.ExternalLink);
            Field(t => t.LinkType);
            Field(t => t.Status);
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.CreatedByUser, type: typeof(IdGraphType));
            Field(t => t.ModifiedByUser, type: typeof(IdGraphType));
        }
    }
}
