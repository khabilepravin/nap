using logic.RequestModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IPracticeTestLogic
    {
        Task RecordTextAnswer(TextAnswerRecord textAnswerRecord);
        //Task<Test> GetByUserTestIdAsync(Guid userTestId);
    }
}
