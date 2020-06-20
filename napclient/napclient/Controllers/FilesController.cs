﻿using logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace napclient.Controllers
{
    public class FilesController : BaseController
    {
        private readonly IQuestionLogic questionLogic;
        private readonly IAnswerLogic answerLogic;
        public FilesController(IQuestionLogic questionLogic,
                               IAnswerLogic answerLogic)
        {
            this.questionLogic = questionLogic;
            this.answerLogic = answerLogic;
        }

        [HttpPost("question/{questionId}")]
        public async Task<IActionResult> AddQuestionImage([FromRoute]Guid questionId)
        {
            var file = Request.Form.Files[0];
            QuestionImage questionImage = null;
            if(file.Length > 0)
            {
                var fileStorage = BuildFileStorage(file);

                questionImage = await questionLogic.AddQuestionImageFile(fileStorage, questionId);
            }
            else
            {
                return BadRequest();
            }

            return Ok(questionImage);
        }

        [HttpPost("answer/{answerId}")]
        public async Task<IActionResult> AddAnswerImage([FromRoute]Guid answerId)
        {
            
            AnswerImage answerImage = null;
            if(Request.Form.Files.Count > 0 && Request.Form.Files[0].Length > 0)
            {
                var file = Request.Form.Files[0];

                var fileStorage = BuildFileStorage(file);
                
                answerImage = await this.answerLogic.AddImageAnswer(fileStorage, answerId);
            }
            else
            {
                return BadRequest();
            }

            return Ok(answerImage);
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