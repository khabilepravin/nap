using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class UserTestInputType : InputObjectGraphType
    {
        public UserTestInputType()
        {
            Name = "UserTestInput";
            Field<IdGraphType>("id");
            Field<IdGraphType>("testId");
            Field<IdGraphType>("userId");
            Field<StringGraphType>("mode");
            Field<IntGraphType>("timeSpentOnTest");
            Field<BooleanGraphType>("isComplete");
        }
    }
}
