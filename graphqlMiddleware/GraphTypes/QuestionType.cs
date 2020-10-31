using dataAccess.Repositories;
using GraphQL;
using GraphQL.Types;
using logic;
using models;
using models.Custom;

namespace graphqlMiddleware.GraphTypes
{
    public class QuestionType : ObjectGraphType<Question>
    {
        public QuestionType(IExplanationRepository explanationRepository,
                            IQuestionFileRepository questionImageRepository,
                            IAnswerLogic answerLogic)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.TestId, type: typeof(IdGraphType));
            Field(t => t.Text);
            Field(t => t.Description);
            Field(t => t.QuestionType);
            Field(t => t.Sequence, type: typeof(IntGraphType));
            Field(t => t.ImageUrl);
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.CreatedByUser, type: typeof(IdGraphType));
            Field(t => t.ModifiedByUser, type: typeof(IdGraphType));
            Field(t => t.Status);
            Field(t => t.FileId, type: typeof(IdGraphType));
            Field(t => t.PlainText);
            Field<ListGraphType<AnswerType>>("answers",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "shuffleSeed" }),
                resolve: context => answerLogic.GetByQuestionIdAndShuffleSeedAsync(context.Source.Id, context.GetArgument<int>("shuffleSeed")));
            Field<ListGraphType<ExplanationType>>("explanations",
                resolve: context => explanationRepository.GetByQuestionId(context.Source.Id));
            Field<ListGraphType<QuestionFileType>>("images",
                resolve: context => questionImageRepository.GetQuestionFiles(context.Source.Id, Constants.ImageFileTypes));
            Field<ListGraphType<QuestionFileType>>("audio",
                resolve: context => questionImageRepository.GetQuestionFiles(context.Source.Id, Constants.AudioFileTypes));

        }
    }
}
