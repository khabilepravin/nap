using logic;
using logic.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace napiControllers
{
    public class PracticeTestController : BaseController
    {
        private readonly IPracticeTestLogic practiceTestLogic;
        public PracticeTestController(IPracticeTestLogic practiceTestLogic)
        {
            this.practiceTestLogic = practiceTestLogic;
        }

        [HttpPost]
        public async Task<IActionResult> RecordTextAnswer([FromBody]TextAnswerRecord testAnswerRecord)
        {
            await this.practiceTestLogic.RecordTextAnswer(testAnswerRecord);

            return Ok();
        }
    }
}
