using dataAccess.Repositories;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using models;

namespace graphqlMiddleware.Mutations
{
    public class QuestionMutation : ObjectGraphType<Question>
    {
        public QuestionMutation(IQuestionRepository questionRepository)
        {
            Field<QuestionType>(
                "createQuestion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<QuestionInputType>> { Name = "question" }
                    ),
                    resolve: context =>
                    {
                        var question = context.GetArgument<Question>("question");
                        return questionRepository.AddAsync(question);
                    });

        }
    }
}
