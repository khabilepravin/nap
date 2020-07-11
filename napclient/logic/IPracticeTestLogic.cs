using logic.RequestModels;
using System.Threading.Tasks;

namespace logic
{
    public interface IPracticeTestLogic
    {
        Task RecordTextAnswer(TextAnswerRecord textAnswerRecord);
    }
}
