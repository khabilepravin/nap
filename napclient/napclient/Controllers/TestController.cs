using dataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Threading.Tasks;

namespace napclient.Controllers
{
    public class TestController : BaseController
    {
        private readonly ITestRepository testRepository;
        public TestController(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add([FromBody]Test test)
        {
            var result = await this.testRepository.AddAsync(test);

            return Ok(result);
        }
    }
}