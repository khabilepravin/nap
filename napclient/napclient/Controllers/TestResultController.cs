using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic;
using logic.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace napclient.Controllers
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