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
            Query = provider.GetRequiredService<TestQuery>();
            Mutation = provider.GetRequiredService<TestMutation>();
        }
    }
}
