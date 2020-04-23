using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace graphqlMiddleware.Queries
{
    public class TestQuery : ObjectGraphType
    {
        private readonly ITestRepository testRepository;
        public TestQuery(ITestRepository testRepository)
        {
            this.testRepository = testRepository;

            Field<ListGraphType<TestType>>
                ("tests",
                resolve: context => this.testRepository.GetAll());

            Field<ListGraphType<TestType>>(
                    "testsBySubject",
                    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "subject" }), 
                    resolve: context => this.testRepository.GetBySubjectAsync(context.GetArgument<string>("subject"))
                );

            Field<TestType>(
                    "test",
                    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name="id"}),
                    resolve: context => this.testRepository.GetByIdAsync(context.GetArgument<Guid>("id"))
                );
        }


    }
}
