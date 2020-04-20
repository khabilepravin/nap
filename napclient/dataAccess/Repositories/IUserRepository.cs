using models;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<string> AddAsync(User user);
        Task<User> GetByIdAsync(string id);
        Task<string> UpdateAsync(User user);
    }
}
