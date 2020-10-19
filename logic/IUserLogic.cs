using models;
using System.Threading.Tasks;

namespace logic
{
    public interface IUserLogic
    {
        Task<User> AddAsync(User user);
    }
}
