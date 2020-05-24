using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class UserTestType : ObjectGraphType<UserTest>
    {
        public UserTestType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.UserId, type: typeof(IdGraphType));
            Field(t => t.TestId, type: typeof(IdGraphType));
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.Status);
        }
    }
}
