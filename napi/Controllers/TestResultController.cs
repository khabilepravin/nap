using logic;
using logic.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace napiControllers
{
    public class TestResultController : BaseController
    {
        private readonly ITestResultLogic testResultLogic;
        public TestResultController(ITestResultLogic testResultLogic)
        {
            this.testResultLogic = testResultLogic;
        }

        [HttpGet("{userTestId}")]
        public async Task<ActionResult<TestResultChartModel>> GetResult([FromRoute]Guid userTestId)
        {
            var result = await this.testResultLogic.GetTestResultPieData(userTestId);

            return Ok(result);
        }
    }
}