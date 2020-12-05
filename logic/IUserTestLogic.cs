using logic.ResponseModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface IUserTestLogic
    {
        Task<TestProgress> GetTestCompletionPercentage(Guid userTestId);
        Task<UserTest> AddUserTest(UserTest userTest);
        Task<UserTest> UpdateUserTest(UserTest userTest);

    }
}
