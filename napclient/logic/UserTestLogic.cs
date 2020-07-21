using dataAccess.Repositories;
using System;
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
    }
}
