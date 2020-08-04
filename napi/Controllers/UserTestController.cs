using logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace napiControllers
{
    public class UserTestController : BaseController
    {
        private readonly IUserTestLogic userTestLogic;
        public UserTestController(IUserTestLogic userTestLogic)
        {
            this.userTestLogic = userTestLogic;
        }

        [HttpGet("progress/{userTestId}")]
        public async Task<IActionResult> GetTestProgressPercentage(Guid userTestId)
        {
            var result = await this.userTestLogic.GetTestCompletionPercentage(userTestId);

            return Ok(result);
        }
    }
}
