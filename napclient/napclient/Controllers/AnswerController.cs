using BrunoZell.ModelBinding;
using logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using napclient.Utility;
using System.Threading.Tasks;

namespace napclient.Controllers
{
    public class AnswerController : BaseController
    {
        private readonly IAnswerLogic answerLogic; 
        public AnswerController(IAnswerLogic answerLogic)
        {
            this.answerLogic = answerLogic;
        }

        [HttpPost]
        public async Task<IActionResult> PostAnswer([ModelBinder(BinderType = typeof(JsonModelBinder))] Answer answer)
        {
            var answerRecord = await this.answerLogic.AddAnswer(answer);
            IFormFile imageFile = null;
            if(Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                imageFile = Request.Form.Files[0];
            }
            
            if (imageFile == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var fileData = FileUtility.BuildFileStorage(imageFile);
                await answerLogic.AddImageAnswer(fileData, answerRecord.Id);
            }

            return Ok(answerRecord);
        }
    }
}
