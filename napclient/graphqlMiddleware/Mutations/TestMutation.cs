using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;

namespace graphqlMiddleware.Mutations
{
    public class TestMutation : ObjectGraphType<Test>
    {

        public TestMutation(ITestRepository testRepository, IQuestionRepository questionRepository)
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

            Field<TestType>(
                "updateTest",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<TestInputType>> { Name = "test" }
                ),
                resolve: context =>
                {
                    var test = context.GetArgument<Test>("test");
                    return testRepository.UpdateAsync(test);
                });

            Field<QuestionType>(
                "addQuestion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<QuestionInputType>> { Name = "question" }
                    ),
                    resolve: context =>
                    {
                        var question = context.GetArgument<Question>("question");
                        return questionRepository.AddAsync(question);
                    });

            Field<QuestionType>(
                "updateQuestion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<QuestionInputType>> { Name="question"}
                    ),
                    resolve: context =>
                    {

                        var question = context.GetArgument<Question>("question");
                        return questionRepository.UpdateAsync(question);
                    });

        }
    }
}
