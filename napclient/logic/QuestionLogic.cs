using dataAccess.Repositories;
using HtmlAgilityPack;
using models;
using System.Threading.Tasks;

namespace logic
{
    public class QuestionLogic : IQuestionLogic 
    {
        private readonly IQuestionRepository questionRepository;
        public QuestionLogic(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task<Question> AddQuestion(Question question)
        {
            question.PlainText = RemoveHtmlTags(question.Text);
            return await this.questionRepository.AddAsync(question);
        }

        private string RemoveHtmlTags(string inputHtml)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(inputHtml);
            return htmlDoc.DocumentNode.InnerText;
        }
    }
}
