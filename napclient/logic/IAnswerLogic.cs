using logic.ResponseModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IAnswerLogic
    {
        Task<Answer> AddAnswer(Answer answer);
        Task<AnswerFile> AddImageAnswer(FileStorage fileStorage, Guid answerId);
        Task AddAnswerAudioFile(Guid answerId, string answerPlainText);
        Task<FileResponse> GetBase64AnswerAudio(Guid answerId);
        Task<FileResponse> GetBase64AnswerImage(Guid answerId);
    }
}
