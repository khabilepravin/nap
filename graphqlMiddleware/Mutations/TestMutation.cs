using dataAccess.Repositories;
using GraphQL;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using logic;
using Microsoft.AspNetCore.Http;
using models;
using System;
using System.IO;

namespace graphqlMiddleware.Mutations
{
    public class TestMutation : ObjectGraphType<Test>
    {

        public TestMutation(ITestRepository testRepository,
                            IQuestionRepository questionRepository,
                            IAnswerRepository answerRepository,
                            IExplanationRepository explanationRepository,
                            ILookupRepository lookupRepository,
                            IUserTestRecordRepository userTestRecordRepository,
                            IQuestionLogic questionLogic,
                            IAnswerLogic answerLogic,
                            IUserTestLogic userTestLogic,
                            IUserLogic userLogic,
                            IPracticeTestLogic practiceTestLogic)
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
                        return questionLogic.AddQuestion(question);
                    });


            Field<QuestionType>(
                "updateQuestion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<QuestionInputType>> { Name = "question" }
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
                        return answerLogic.AddAnswer(answer); // answerRepository.AddAsync(answer);
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

            Field<LookupGroupType>(
                    "addLookupGroup",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<LookupGroupInputType>> { Name = "lookupGroup" }
                        ),
                        resolve: context =>
                        {
                            var lookupGroup = context.GetArgument<LookupGroup>("lookupGroup");
                            return lookupRepository.AddGroupAsync(lookupGroup);
                        });

            Field<LookupValueType>(
                    "addLookupValue",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<LookupValueInputType>> { Name = "lookupValue" }
                        ),
                        resolve: context =>
                        {
                            var lookupValue = context.GetArgument<LookupValue>("lookupValue");
                            return lookupRepository.AddValueAsync(lookupValue);
                        });

            Field<UserTestType>(
                    "addUserTest",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserTestInputType>> { Name = "userTest" }
                        ),
                        resolve: context =>
                        {
                            var userTest = context.GetArgument<UserTest>("userTest");
                            return userTestLogic.AddUserTest(userTest);
                        });


            Field<UserTestRecordType>(
                    "addUserTestRecord",
                    arguments: new QueryArguments(
                            new QueryArgument<NonNullGraphType<UserTestRecordInputType>> { Name = "userTestRecord" }
                        ),
                    resolve: context =>
                    {
                        var userTestRecord = context.GetArgument<UserTestRecord>("userTestRecord");
                        return practiceTestLogic.RecordAnswer(userTestRecord);
                    });

            Field<BooleanGraphType>(
                    "deleteAnswerById",
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                    resolve: context => answerRepository.DeleteAsync(context.GetArgument<Guid>("id"))
                );

            Field<BooleanGraphType>(
                    "deleteQuestionById",
                    arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                    resolve: context => questionRepository.DeleteAsync(context.GetArgument<Guid>("id"))
                );

            Field<UserType>(
                  "addUser",
                  arguments: new QueryArguments(
                          new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                      ),
                  resolve: context =>
                  {
                      var user = context.GetArgument<User>("user");
                      return userLogic.AddAsync(user);
                  });


            Field<UserType>(
                  "checkUserExistence",
                  arguments: new QueryArguments(
                          new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                      ),
                  resolve: context =>
                  {
                      var user = context.GetArgument<User>("user");
                      return userLogic.CheckUserExistence(user);
                  });

            Field<UserTestType>(
                "updateUserTest",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserTestInputType>> { Name = "userTest" }
                    ),
                    resolve: context =>
                    {
                        var userTest = context.GetArgument<UserTest>("userTest");
                        return userTestLogic.UpdateUserTest(userTest);
                    });

            //Field<UserType>(
            //      "markTestAsComplete",
            //      arguments: new QueryArguments(
            //              new QueryArgument<IdGraphType> { Name = "userTestId" },
            //              new QueryArgument<IntGraphType> { Name= "timeSpentOnTestInSeconds" }
            //          ),
            //      resolve: context =>
            //      {
            //          var userTestId = context.GetArgument<Guid>("userTestId");
            //          var timeSpentOnTest = context.GetArgument<int>("timeSpentOnTestInSeconds");
            //          return practiceTestLogic.MarkTestComplete(userTestId, timeSpentOnTest);
            //      });
        }
    }
}
