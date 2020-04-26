using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class AnswerType : ObjectGraphType<Answer>
    {
        public AnswerType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.QuestionId, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.ImageUrl);
            Field(t => t.Type);
            Field(t => t.IsCorrect, type: typeof(BooleanGraphType));
            Field(t => t.Status);            
        }
    }
}
