using GraphQL.Types;
using GraphQL.Utilities;
using graphqlMiddleware.Mutations;
using graphqlMiddleware.Queries;
using System;

namespace graphqlMiddleware.NapSchema
{
    public class TestSchema : Schema
    {
        public TestSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService(typeof(TestQuery)) as IObjectGraphType;
            Mutation = provider.GetService(typeof(TestMutation)) as IObjectGraphType;
        }
    }
}
