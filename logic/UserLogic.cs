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
            //if (user.SocialLoginId?.Contains("google") == true)
            //{
              //  user.Email = $"{user.UserName}@gmail.com";
            //}

            return await this.userRepository.AddAsync(user);
        }
    }
}
