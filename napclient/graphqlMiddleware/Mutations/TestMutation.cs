using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;

namespace graphqlMiddleware.Mutations
{
    public class TestMutation : ObjectGraphType<Test>
    {
     
        public TestMutation(ITestRepository testRepository)
        {
            Field<TestType>(
                "createTest",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<TestInputType>> { Name = "test" }
                ),
                resolve: context =>
                {
                    var test = context.GetArgument<Test>("test");
                    return testRepository.AddAsync(test);
                });
        }
    }
}
