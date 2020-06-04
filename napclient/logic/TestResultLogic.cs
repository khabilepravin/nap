using dataAccess.Repositories;
using logic.ResponseModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace logic
{
    public class TestResultLogic : ITestResultLogic
    {
        private readonly IUserTestRecordRepository userTestRecordRepository;
        public TestResultLogic(IUserTestRecordRepository userTestRecordRepository)
        {
            this.userTestRecordRepository = userTestRecordRepository;
        }

        public async Task<TestResultChartModel> GetTestResultPieData(Guid userTestId)
        {
            var testResults = await this.userTestRecordRepository.GetByUserTestId(userTestId);

            TestResultChartModel testResultChartModel = null;
            if(testResults != null)
            {
                testResultChartModel = new TestResultChartModel();
                testResultChartModel.Labels = new List<string>() { "Correct", "InCorrect" };

                var rightAnswer = testResults.Count(t => t.IsCorrect);
                var wrongAnswer = testResults.Count(t => t.IsCorrect == false);
                testResultChartModel.DataPoints = new List<int>() { rightAnswer, wrongAnswer };
            }

            return testResultChartModel;
        }
    }
}
