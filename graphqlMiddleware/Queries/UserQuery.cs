using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using System;

namespace graphqlMiddleware.Queries
{
    public class UserQuery : ObjectGraphType
    {
        private readonly IUserRepository userRepository;
        public UserQuery(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            Field<UserType>(
                    "user",
                    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                    resolve: context => this.userRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
                );
        }
    }
}
