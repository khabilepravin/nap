using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IAnswerLogic
    {
        Task<Answer> AddAnswer(Answer answer);
    }
}
