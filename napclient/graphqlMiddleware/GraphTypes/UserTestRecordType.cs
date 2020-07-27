using GraphQL.Types;
using models;


namespace graphqlMiddleware.GraphTypes
{
    public class UserTestRecordType : ObjectGraphType<UserTestRecord>
    {
        public UserTestRecordType()
        {   
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.UserTestId, type: typeof(IdGraphType));
            Field(t => t.QuestionId, type: typeof(IdGraphType));
            Field(t => t.AnswerId, type: typeof(IdGraphType));
            Field(t => t.IsCorrect);
            Field(t => t.AnswerText, nullable: true);
        }
    }
}
