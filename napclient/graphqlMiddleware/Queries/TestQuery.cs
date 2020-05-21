﻿using dataAccess.Repositories;
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
                        IAnswerRepository answerRepository)
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

        }

    }
}
