using dataAccess.Repositories;
using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class QuestionFileType : ObjectGraphType<QuestionFile>
    {
        public QuestionFileType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.FileId, type: typeof(IdGraphType));
            Field(f => f.QuestionId, type: typeof(IdGraphType));
        }
    }
}
