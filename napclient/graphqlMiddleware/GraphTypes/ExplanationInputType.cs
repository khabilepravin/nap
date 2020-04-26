using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class ExplanationInputType : InputObjectGraphType
    {
        public ExplanationInputType()
        {
            Name = "ExplanationInput";
            Field<NonNullGraphType<IdGraphType>>("questionId");
            Field<StringGraphType>("textExplanation");
            Field<StringGraphType>("externalLink");
            Field<StringGraphType>("linkType");
            Field<StringGraphType>("status");
            Field<IdGraphType>("createdByUser");
            Field<IdGraphType>("modifiedByUser");
            Field<IdGraphType>("id");
        }
    }
}

