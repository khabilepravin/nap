using dataAccess.Repositories;
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
            return await this.questionRepository.AddAsync(question);
        }
    }
}
