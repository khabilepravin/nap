using dataAccess.Repositories;
using externalServices;
using logic.ResponseModels;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logic
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IFileStorageRepository fileStorageRepository;
        private readonly IQuestionFileRepository questionImageRepository;
        private readonly ITextToSpeech textToSpeech;
        public QuestionLogic(IQuestionRepository questionRepository,
                            IFileStorageRepository fileStorageRepository,
                            IQuestionFileRepository questionImageRepository,
                            ITextToSpeech textToSpeech)
        {
            this.questionRepository = questionRepository;
            this.fileStorageRepository = fileStorageRepository;
            this.questionImageRepository = questionImageRepository;
            this.textToSpeech = textToSpeech;
        }

        public async Task<Question> AddQuestion(Question question)
        {
            question.PlainText = HtmlHelper.RemoveHtmlTags(question.Text);
            var questionRecord = await this.questionRepository.AddAsync(question);
            if (questionRecord != null)
            {
                await this.AddQuestionAudioFile(questionRecord.Id, questionRecord.PlainText, questionRecord.Description);
            }
            return questionRecord;
        }

        public async Task<Question> UpdateQuestion(Question question, FileStorage imageData)
        {
            // Do implementation
            question.PlainText = HtmlHelper.RemoveHtmlTags(question.Text);
            var questionRecord = await this.questionRepository.UpdateAsync(question);

            var questionAudio = await this.fileStorageRepository.GetByQuestionAsync(question.Id, new List<string> { "audio/mpeg" });
            var questionImage = await this.fileStorageRepository.GetByAnswerAsync(question.Id, new List<string> { "image/png", "image/jpeg" });

            if(questionAudio == null)
            {
                await AddQuestionAudioFile(question.Id, question.PlainText, question.Description);
            }
            else
            {
                await UpdateQuestionAudioFile(question.Id, question.PlainText, question.Description, questionAudio);
            }

            if(imageData != null)
            {
                if(questionImage == null)
                {
                    await this.fileStorageRepository.AddAsync(questionImage);
                }
                else
                {
                    imageData.Id = questionImage.Id;
                    await this.fileStorageRepository.UpdateAsync(imageData);
                }
            }

            return question;
        }

        public async Task<QuestionFile> AddQuestionImageFile(FileStorage fileStorage, Guid questionId)
        {
            var fileStorageRecord = await this.fileStorageRepository.AddAsync(fileStorage);

            QuestionFile questionImage = null;
            if (fileStorageRecord != null)
            {
                questionImage = await this.questionImageRepository.AddAsync(new QuestionFile
                {
                    QuestionId = questionId,
                    FileId = fileStorageRecord.Id
                });
            }
            else
            {
                throw new Exception("Failed to store image file");
            }

            return questionImage;
        }

        public async Task<FileResponse> GetBase64QuestionImage(Guid questionId)
        {
            var fileStorage = await this.fileStorageRepository.GetByQuestionAsync(questionId, new List<string> { "image/png", "image/jpeg" });

            if (fileStorage == null)
            {
                return null;
            }
            else
            {
                return new FileResponse { FileType = fileStorage.FileType, Base64Data = Convert.ToBase64String(fileStorage.Data) };
            }
        }

        public async Task<FileResponse> GetBase64QuestionAudio(Guid questionId)
        {
            var fileStorage = await this.fileStorageRepository.GetByQuestionAsync(questionId, new List<string> { "audio/mpeg" });

            if(fileStorage == null)
            {
                return null;
            }
            else
            {
                return new FileResponse { FileType = fileStorage.FileType, Base64Data = Convert.ToBase64String(fileStorage.Data) };
            }
        }

        public async Task AddQuestionAudioFile(Guid questionId, string questionPlainText, string questionDescription)
        {
            var textToConvertToAudio = questionPlainText + questionDescription;
            var audioFileData = this.textToSpeech.ConvertTextToSpeech(textToConvertToAudio);

            if (audioFileData != null)
            {
                var fileStorage = await this.fileStorageRepository.AddAsync(new FileStorage
                {
                    Data = audioFileData,
                    Extension = ".mp3",
                    FileType = "audio/mpeg",
                    Name = $"question_{questionId}"
                });

                if (fileStorage != null)
                {
                    await this.questionImageRepository.AddAsync(new QuestionFile
                    {
                        FileId = fileStorage.Id,
                        QuestionId = questionId
                    });
                }
            }
        }

        public async Task UpdateQuestionAudioFile(Guid questionId, string questionPlainText, string questionDescription, FileStorage questionAudio)
        {
            var textToConvertToAudio = questionPlainText + questionDescription;
            var audioFileData = this.textToSpeech.ConvertTextToSpeech(textToConvertToAudio);

            if(audioFileData == null)
            {
                throw new Exception("Failed to convert using speech to text external service");
            }
            else
            {
                questionAudio.Data = audioFileData;
                await this.fileStorageRepository.UpdateAsync(questionAudio);
            }
        }

        public async Task<IEnumerable<Question>> GetShuffledQuestionsByTestIdAsync(Guid testId, int shuffleSeed)
        {
            var questions = await this.questionRepository.GetQuestionsByTestIdAsync(testId);

            return Shuffler.Shuffle<Question>(questions.ToList(), shuffleSeed);
        }
    }
}
