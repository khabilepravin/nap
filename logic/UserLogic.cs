using dataAccess.Repositories;
using models;
using System.Threading.Tasks;

namespace logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AddAsync(User user)
        {
            var existingUser = await this.userRepository.GetByEmailId(user.Email);
            if(existingUser == null)
            {
                return await this.userRepository.AddAsync(user);
            }
            else
            {
                return existingUser;
            }
        }

        public async Task<User> CheckUserExistence(User user)
        {
            var existingUser = await this.userRepository.GetByEmailId(user.Email);

            if(existingUser == null)
            {
                return await userRepository.AddAsync(user);
            }
            else
            {
                return existingUser;
            }
        }

        public async Task<User> AddChildUser(User user)
        {
            return await userRepository.AddAsync(user);
        }
    }
}
