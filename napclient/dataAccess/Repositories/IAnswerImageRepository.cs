using models;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IAnswerImageRepository
    {
        Task<AnswerImage> AddAsync(AnswerImage answerImage);
    }
}
