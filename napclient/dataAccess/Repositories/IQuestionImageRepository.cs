using models;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionImageRepository
    {
        Task<QuestionImage> AddAsync(QuestionImage questionImage);
    }
}
