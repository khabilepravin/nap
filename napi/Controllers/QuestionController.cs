﻿using BrunoZell.ModelBinding;
using logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using napiUtility;
using System;
using System.Threading.Tasks;

namespace napiControllers
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
            IFormFile imageFile = null;
            if (Request.Form.Files?.Count > 0)
            {
                imageFile = Request.Form.Files[0];
            }
            if (imageFile == null)
            {
                //return BadRequest(ModelState);
            }
            else
            {
                var fileData = FileUtility.BuildFileStorage(imageFile);
                await questionLogic.AddQuestionImageFile(fileData, questionRecord.Id);
            }

            return Ok(questionRecord);
        } 

        [HttpPut]
        public async Task<IActionResult> PutQuestion([ModelBinder(BinderType = typeof(JsonModelBinder))] Question question)
        {
            IFormFile imageFile = null;
            if (Request.Form.Files?.Count > 0)
            {
                imageFile = Request.Form.Files[0];
            }

            var imageData = imageFile == null ? null : FileUtility.BuildFileStorage(imageFile);
            var questionRecord = await questionLogic.UpdateQuestion(question, imageData);

            return Ok(questionRecord);
        }

        [HttpGet("{questionId}/images")]
        public async Task<IActionResult> GetQuestionImage([FromRoute]Guid questionId)
        {
            var imageData = await this.questionLogic.GetBase64QuestionImage(questionId);

            if (imageData == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(imageData);
            }
        }

        [HttpGet("{questionId}/audio")]
        public async Task<IActionResult> GetQuestionAudio([FromRoute] Guid questionId)
        {
            var audioData = await this.questionLogic.GetBase64QuestionAudio(questionId);

            if (audioData == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(audioData);
            }
        }
    }
}
