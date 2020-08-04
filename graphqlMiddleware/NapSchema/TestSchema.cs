using GraphQL;
using GraphQL.Types;
using graphqlMiddleware.Mutations;
using graphqlMiddleware.Queries;

namespace graphqlMiddleware.NapSchema
{
    public class TestSchema : Schema
    {
        public TestSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TestQuery>();
            Mutation = resolver.Resolve<TestMutation>();
        }
    }
}
