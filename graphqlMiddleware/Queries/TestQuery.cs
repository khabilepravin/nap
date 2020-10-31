using dataAccess.Repositories;
using GraphQL;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;
using System;

namespace graphqlMiddleware.Queries
{
    public class TestQuery : ObjectGraphType
    {
        
        public TestQuery(ITestRepository testRepository, 
                        IQuestionRepository questionRepository,
                        ILookupRepository lookupRepository,
                        IAnswerRepository answerRepository,
                        IUserTestRepository userTestRepository,
                        IUserTestRecordRepository userTestRecordRepository,
                        IUserRepository userRepository)
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
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name="id"}),
                    resolve: context => testRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
                );

            Field<ListGraphType<QuestionType>>(
                        "questions",
                        arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "testId" }),
                        resolve: context => questionRepository.GetQuestionsByTestIdAsync(context.GetArgument<Guid>("testId"))
                );

            Field<QuestionType>(
                        "question",
                        arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "questionId" }),
                        resolve: context => questionRepository.GetQuestionById(context.GetArgument<Guid>("questionId"))
              );

            Field<ListGraphType<LookupGroupType>>(
                        "lookupGroups",
                        resolve: context => lookupRepository.GetGroupsAsync()
                );

            Field<ListGraphType<LookupValueType>>(
                    "lookupValues",
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "groupId" }),
                    resolve: context => lookupRepository.GetValuesByGroupAsync(context.GetArgument<Guid>("groupId"))
                );

            Field<ListGraphType<AnswerType>>(
                    "answers",
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name="questionId"}),
                    resolve: context => answerRepository.GetByQuestionIdAsync(context.GetArgument<Guid>("questionId"))
                );

            Field<UserTestType>(
             "userTestById",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userTestRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
             );

            Field<TestType>(
                    "testByUserTestId",
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "userTestId" }),
                    resolve: context => testRepository.GetByUserTestIdAsync(context.GetArgument<Guid>("userTestId"))
                );

            Field<UserTestRecordType>(
                "userTestRecord",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "userTestId" },
                                               new QueryArgument<IdGraphType> { Name ="questionId" }),
                resolve: context => userTestRecordRepository.GetByUserTestAndQuestionId(context.GetArgument<Guid>("userTestId"), 
                context.GetArgument<Guid>("questionId"))
            );

            Field<ListGraphType<TestType>>
                            ("testsByTypeAndYear",
                            arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name="testType"},
                                                            new QueryArgument<StringGraphType> { Name="year"}),
                            resolve: context => testRepository.GetByTypeAndYear(context.GetArgument<string>("testType"), 
                            context.GetArgument<string>("year")));

            Field<UserType>
                            ("userBySocialId",
                            arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "socialId" }),
                            resolve: context => userRepository.GetBySocialId(context.GetArgument<string>("socialId")));

        }

    }
}
