using GraphQL;
using GraphQL.Types;
using graphqlMiddleware.Queries;

namespace graphqlMiddleware.NapSchema
{
    public class UserSchema : Schema
    {
        public UserSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
        }
    }
}
