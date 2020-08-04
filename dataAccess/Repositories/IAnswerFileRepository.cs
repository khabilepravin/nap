using models;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IAnswerFileRepository
    {
        Task<AnswerFile> AddAsync(AnswerFile answerImage);
    }
}
