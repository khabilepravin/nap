using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IUserLogic
    {
        Task<User> AddAsync(User user);
        Task<User> CheckUserExistence(User user);
    }
}
