using logic.ResponseModels;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface ITestResultLogic
    {
        Task<TestResultChartModel> GetTestResultPieData(Guid userTestId);
    }
}
