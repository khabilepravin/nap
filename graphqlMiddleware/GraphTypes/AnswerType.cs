using dataAccess.Repositories;
using GraphQL.Types;
using models;
using models.Custom;

namespace graphqlMiddleware.GraphTypes
{
    public class AnswerType : ObjectGraphType<Answer>
    {
        public AnswerType(IAnswerFileRepository answerFileRepository)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.QuestionId, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.ImageUrl);
            Field(t => t.Type);
            Field(t => t.IsCorrect, type: typeof(BooleanGraphType));
            Field(t => t.Status);
            Field(t => t.Sequence);
            Field(t => t.PlainText);
            Field<ListGraphType<AnswerFileType>>("images",
                resolve: context => answerFileRepository.GetAnswerFiles(context.Source.Id, Constants.ImageFileTypes));
            Field<ListGraphType<AnswerFileType>>("audio",
                resolve: context => answerFileRepository.GetAnswerFiles(context.Source.Id, Constants.AudioFileTypes));
        }
    }
}
