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
            Field<IdGraphType>("modifiedByUser");
            Field<IdGraphType>("id");
            Field<StringGraphType>("status");
            Field<StringGraphType>("difficultyLevel");
            Field<IdGraphType>("fileId");
            Field<StringGraphType>("category");
        }
    }
}
