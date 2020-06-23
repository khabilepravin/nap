using BrunoZell.ModelBinding;
using logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using System.IO;
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
                var fileData = BuildFileStorage(imageFile);
                await questionLogic.AddQuestionImageFile(fileData, questionRecord.Id);
            }

            return Ok(questionRecord);
        } 

        private FileStorage BuildFileStorage(IFormFile formFile)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                formFile.CopyTo(ms);
                fileBytes = ms.ToArray();

            }

            return new FileStorage
            {
                Data = fileBytes,
                FileType = formFile.ContentType,
                Name = formFile.FileName
            };
        }
    }
}
