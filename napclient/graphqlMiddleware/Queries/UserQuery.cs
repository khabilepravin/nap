using dataAccess.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graphqlMiddleware.Queries
{
    public class UserQuery : ObjectGraphType
    {
        private readonly IUserRepository userRepository;
        public UserQuery(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            //Field<UserType>(
            //        "test",
            //        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
            //        resolve: context => this.testRepository.GetByIdAsync(context.GetArgument<string>("id"))
            //    );
        }
    }
}
