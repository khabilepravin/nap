using logic.ResponseModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IQuestionLogic
    {
        Task<Question> AddQuestion(Question question);
        Task<QuestionImage> AddQuestionImageFile(FileStorage fileStorage, Guid questionId);
        Task<ImageResponse> GetBase64QuestionImage(Guid questionId); 
    }
}
