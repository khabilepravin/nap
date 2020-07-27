using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class UserTestRecordInputType : InputObjectGraphType
    {
        public UserTestRecordInputType()
        {
            Name = "UserTestRecordInput";
            Field<NonNullGraphType<IdGraphType>>("userTestId");
            Field<NonNullGraphType<IdGraphType>>("questionId");
            Field<NonNullGraphType<IdGraphType>>("answerId");
            Field<NonNullGraphType<BooleanGraphType>>("isCorrect");
            Field<StringGraphType>("answerText");
        }
    }
}
