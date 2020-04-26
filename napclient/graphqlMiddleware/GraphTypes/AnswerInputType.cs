using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class AnswerInputType : InputObjectGraphType
    {
        public AnswerInputType()
        {
            Name = "AnswerInput";
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<StringGraphType>("description");
            Field<StringGraphType>("imageUrl");
            Field<StringGraphType>("type");            
            Field<IdGraphType>("questionId");
            Field<BooleanGraphType>("isCorrect");
            Field<StringGraphType>("status");
            Field<IdGraphType>("id");
            Field<IntGraphType>("sequence");

        }
    }
}
