using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class QuestionInputType : InputObjectGraphType
    {
        public QuestionInputType()
        {
            Name = "QuestionInput";
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<StringGraphType>("description");
            Field<StringGraphType>("questionType");
            Field<IdGraphType>("testId");
            Field<IntGraphType>("sequence");
            Field<StringGraphType>("imageUrl");
            Field<DateGraphType>("createdAt");
            Field<IdGraphType>("createdByUser");
            Field<IdGraphType>("id");
        }
    }
}
