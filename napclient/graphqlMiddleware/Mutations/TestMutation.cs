using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;

namespace graphqlMiddleware.Mutations
{
    public class TestMutation : ObjectGraphType<Test>
    {

        public TestMutation(ITestRepository testRepository, 
                            IQuestionRepository questionRepository,
                            IAnswerRepository answerRepository,
                            IExplanationRepository explanationRepository)
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

            Field<AnswerType>(
                "addAnswer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AnswerInputType>> { Name = "answer" }
                    ),
                    resolve: context =>
                    {
                        var answer = context.GetArgument<Answer>("answer");
                        return answerRepository.AddAsync(answer);
                    });

            Field<AnswerType>(
                    "updateAnswer",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<AnswerInputType>> { Name = "answer" }
                        ),
                        resolve: context =>
                        {

                            var answer = context.GetArgument<Answer>("answer");
                            return answerRepository.UpdateAsync(answer);
                        });

            Field<ExplanationType>(
                "addExplanation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExplanationInputType>> { Name = "explanation" }
                    ),
                    resolve: context =>
                    {
                        var explanation = context.GetArgument<Explanation>("explanation");
                        return explanationRepository.AddAsync(explanation);
                    });

            Field<ExplanationType>(
                    "updateExplanation",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<ExplanationInputType>> { Name = "explanation" }
                        ),
                        resolve: context =>
                        {

                            var explanation = context.GetArgument<Explanation>("explanation");
                            return explanationRepository.UpdateAsync(explanation);
                        });

        }
    }
}
