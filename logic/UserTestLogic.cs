using dataAccess.Repositories;
using models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace logic
{
    public class UserTestLogic : IUserTestLogic
    {
        private readonly IUserTestRepository userTestRepository;
        private readonly IUserTestRecordRepository userTestRecordRepository;

        public UserTestLogic(IUserTestRepository userTestRepository, IUserTestRecordRepository userTestRecordRepository)
        {
            this.userTestRepository = userTestRepository;
            this.userTestRecordRepository = userTestRecordRepository;
        }

        public async Task<double> GetTestCompletionPercentage(Guid userTestId)
        {
            var numberOfQuestionsInATest = await this.userTestRepository.GetTotalNumberOfQuestions(userTestId);
            var numberOfAnsweredQuestions = await this.userTestRecordRepository.GetNumberOfAnsweredQuestions(userTestId);

            return Math.Round(Convert.ToDouble((100*numberOfAnsweredQuestions) / numberOfQuestionsInATest));
        }

        public async Task<UserTest> AddUserTest(UserTest userTest)
        {
            var previousUserTestAttempts = await this.userTestRepository.GetByUserAndTestIdAsync(userTest.UserId, userTest.TestId);
            int nestShuffleSeed = 0;

            if(previousUserTestAttempts != null)
            {
                nestShuffleSeed = previousUserTestAttempts.Count() + 1;
            }

            userTest.ShuffleSeed = nestShuffleSeed;

            return await this.userTestRepository.AddAsync(userTest);
        }
    }
}
