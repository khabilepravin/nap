using dataAccess.Repositories;
using models;
using System.Threading.Tasks;

namespace logic
{
    public class AnswerLogic : IAnswerLogic
    {
        private readonly IAnswerRepository answerRepository;
        public AnswerLogic(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            answer.PlainText = HtmlHelper.RemoveHtmlTags(answer.Text);
            return await this.answerRepository.AddAsync(answer);
        }
    }
}
