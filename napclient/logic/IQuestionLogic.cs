using logic.ResponseModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IQuestionLogic
    {
        Task<Question> AddQuestion(Question question);
        Task<QuestionFile> AddQuestionImageFile(FileStorage fileStorage, Guid questionId);
        Task<FileResponse> GetBase64QuestionImage(Guid questionId);
        Task<FileResponse> GetBase64QuestionAudio(Guid questionId);
        Task AddQuestionAudioFile(Guid questionId, string questionPlainText);
    }
}
