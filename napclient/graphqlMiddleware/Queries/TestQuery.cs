using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using System;

namespace graphqlMiddleware.Queries
{
    public class TestQuery : ObjectGraphType
    {
        
        public TestQuery(ITestRepository testRepository, IQuestionRepository questionRepository)
        {
            Field<ListGraphType<TestType>>
                ("tests",
                resolve: context => testRepository.GetAll());

            Field<ListGraphType<TestType>>(
                    "testsBySubject",
                    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "subject" }), 
                    resolve: context => testRepository.GetBySubjectAsync(context.GetArgument<string>("subject"))
                );

            Field<TestType>(
                    "test",
                    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name="id"}),
                    resolve: context => testRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
                );

            Field<ListGraphType<QuestionType>>(
                        "questions",
                        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "testId" }),
                        resolve: context => questionRepository.GetQuestionsByTestIdAsync(context.GetArgument<Guid>("testId"))
                );

        }


    }
}
