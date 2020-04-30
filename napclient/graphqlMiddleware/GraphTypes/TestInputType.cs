using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class TestInputType : InputObjectGraphType
    {
        public TestInputType()
        {
            Name = "TestInput";
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<StringGraphType>("description");
            Field<IntGraphType>("sequence");
            Field<StringGraphType>("subject");
            Field<IntGraphType>("durationMinutes");
            Field<IdGraphType>("id");
            Field<StringGraphType>("status");
            Field<StringGraphType>("difficultyLevel");
        }
    }
}
