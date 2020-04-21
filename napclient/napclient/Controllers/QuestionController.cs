using dataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Threading.Tasks;

namespace napclient.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionRepository questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add([FromBody]Question question)
        {
            var result = await this.questionRepository.AddAsync(question);

            return Ok(result);
        }
    }
}