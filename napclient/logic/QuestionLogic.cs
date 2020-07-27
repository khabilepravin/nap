using dataAccess.Repositories;
using externalServices;
using logic.ResponseModels;
using models;
using System;
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
            return await this.questionRepository.AddAsync(question);
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

        public async Task<ImageResponse> GetBase64QuestionImage(Guid questionId)
        {
            var fileStorage = await this.fileStorageRepository.GetByQuestionAsync(questionId);

            if (fileStorage == null)
            {
                return null;
            }
            else
            {
                return new ImageResponse { ImageFileType = fileStorage.FileType, Base64ImageData = Convert.ToBase64String(fileStorage.Data) };
            }
        }

        public async Task<FileStorage> GetAudioByQuestionId(Guid questionId)
        {
            return await this.fileStorageRepository.GetByQuestionAsync(questionId, ".mp3");
        }

        public async Task AddQuestionAudioFile(Guid questionId, string questionPlainText)
        {
            var audioFileData = this.textToSpeech.ConvertTextToSpeech(questionPlainText);

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
    }
}
