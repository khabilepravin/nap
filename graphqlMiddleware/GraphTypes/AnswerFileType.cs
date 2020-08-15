using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class AnswerFileType : ObjectGraphType<AnswerFile>
    {
        public AnswerFileType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.FileId, type: typeof(IdGraphType));
            Field(f => f.AnswerId, type: typeof(IdGraphType));
        }
    }
}
