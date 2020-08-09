using models;
using System;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IAnswerFileRepository
    {
        Task<AnswerFile> AddAsync(AnswerFile answerImage);        
    }
}
