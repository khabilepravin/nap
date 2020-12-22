using logic.RequestModels;
using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IPracticeTestLogic
    {
        Task RecordTextAnswer(TextAnswerRecord textAnswerRecord);
        Task<UserTestRecord> RecordAnswer(UserTestRecord userTestRecord);
        //Task<Test> GetByUserTestIdAsync(Guid userTestId);
    }
}
