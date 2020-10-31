using GraphQL.Types;
using GraphQL.Utilities;
using graphqlMiddleware.Queries;
using System;

namespace graphqlMiddleware.NapSchema
{
    public class UserSchema : Schema
    {
        public UserSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<UserQuery>();
        }
    }
}
