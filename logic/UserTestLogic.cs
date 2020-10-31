using dataAccess.Repositories;
using logic.ResponseModels;
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
        private readonly IQuestionRepository questionRepository;

        public UserTestLogic(IUserTestRepository userTestRepository, 
                            IUserTestRecordRepository userTestRecordRepository, 
                            IQuestionRepository questionRepository)
        {
            this.userTestRepository = userTestRepository;
            this.userTestRecordRepository = userTestRecordRepository;
            this.questionRepository = questionRepository;
        }

        public async Task<TestProgress> GetTestCompletionPercentage(Guid userTestId)
        {
            var numberOfQuestionsInATest = await this.userTestRepository.GetTotalNumberOfQuestions(userTestId);
            var numberOfAnsweredQuestions = await this.userTestRecordRepository.GetNumberOfAnsweredQuestions(userTestId);

            return new TestProgress
            {
                Percentage = Math.Round(Convert.ToDouble((100 * numberOfAnsweredQuestions) / numberOfQuestionsInATest)),
                Description = $"{numberOfAnsweredQuestions}/{numberOfQuestionsInATest}",
                NextQuestionIndex = numberOfAnsweredQuestions == numberOfQuestionsInATest ? (numberOfQuestionsInATest - 1) : numberOfAnsweredQuestions
            };
        }

        public async Task<UserTest> AddUserTest(UserTest userTest)
        {
            var previousUserTestAttempts = await this.userTestRepository.GetByUserAndTestIdAsync(userTest.UserId, userTest.TestId);
            int nextShuffleSeed = 0;

            if(previousUserTestAttempts != null)
            {
                nextShuffleSeed = previousUserTestAttempts.Count() + 1;
            }

            userTest.ShuffleSeed = nextShuffleSeed;

            return await this.userTestRepository.AddAsync(userTest);
        }
    }
}
