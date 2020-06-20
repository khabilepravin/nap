using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IAnswerLogic
    {
        Task<Answer> AddAnswer(Answer answer);
        Task<AnswerImage> AddImageAnswer(FileStorage fileStorage, Guid answerId);
    }
}
