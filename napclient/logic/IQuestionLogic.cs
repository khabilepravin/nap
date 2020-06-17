using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IQuestionLogic
    {
        Task<Question> AddQuestion(Question question);
    }
}
