using BrunoZell.ModelBinding;
using logic;
using Microsoft.AspNetCore.Mvc;
using models;
using napclient.Utility;
using System;
using System.Threading.Tasks;

namespace napclient.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionLogic questionLogic;
        public QuestionController(IQuestionLogic questionLogic)
        {
            this.questionLogic = questionLogic;
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([ModelBinder(BinderType = typeof(JsonModelBinder))] Question question)
        {
            var questionRecord = await this.questionLogic.AddQuestion(question);

            var imageFile = Request.Form.Files != null ? Request.Form.Files[0] : null;
            if (imageFile == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var fileData = FileUtility.BuildFileStorage(imageFile);
                await questionLogic.AddQuestionImageFile(fileData, questionRecord.Id);
            }

            return Ok(questionRecord);
        } 

        [HttpGet("{questionId}/images")]
        public async Task<IActionResult> GetQuestionImage([FromRoute]Guid questionId)
        {
            var base64EncodedData = await this.questionLogic.GetBase64QuestionImage(questionId);

            if (string.IsNullOrWhiteSpace(base64EncodedData))
            {
                return NoContent();
            }
            else
            {
                return Ok(base64EncodedData);
            }
        }
    }
}
