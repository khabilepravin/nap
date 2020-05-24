using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class UserTestInputType : InputObjectGraphType
    {
        public UserTestInputType()
        {
            Name = "UserTestInput";
            Field<NonNullGraphType<IdGraphType>>("testId");
            Field<NonNullGraphType<IdGraphType>>("userId");

        }
    }
}
