using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("userName");
            Field<StringGraphType>("userType");
            Field<StringGraphType>("password");
            Field<StringGraphType>("parentUserId");
            Field<StringGraphType>("status");
            Field<StringGraphType>("socialLoginId");
            Field<StringGraphType>("socialProfilePicUrl");
        }
    }
}
