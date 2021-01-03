using dataAccess.Repositories;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public class TestLogic : ITestLogic
    {
        private readonly ITestRepository testRepository;
        public TestLogic(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task<bool> UpdateStatus(Guid testId, string status)
        {
            var test = await this.testRepository.GetByIdAsync(testId);

            if(test != null)
            {
                test.PublishedStatus = status;
            }

            await this.testRepository.UpdateAsync(test);

            return true;
        }
    }
}
