using models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IQuestionRepository
    {
        Task<string> AddAsync(Question question);
        Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(string testId);
        Task<string> UpdateAsync(Question question);
    }
}
