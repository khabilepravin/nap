using GraphQL;
using GraphQL.Types;
using graphqlMiddleware.Queries;
using models;

namespace graphqlMiddleware.NapSchema
{
    public class TestSchema : Schema
    {
        public TestSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TestQuery>();
        }
    }
}
