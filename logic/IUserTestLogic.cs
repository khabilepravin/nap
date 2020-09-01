using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IUserTestLogic
    {
        Task<double> GetTestCompletionPercentage(Guid userTestId);
        Task<UserTest> AddUserTest(UserTest userTest);
    }
}
