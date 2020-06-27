using dataAccess.Repositories;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IFileStorageRepository fileStorageRepository;
        private readonly IQuestionImageRepository questionImageRepository;
        public QuestionLogic(IQuestionRepository questionRepository,
                            IFileStorageRepository fileStorageRepository,
                            IQuestionImageRepository questionImageRepository)
        {
            this.questionRepository = questionRepository;
            this.fileStorageRepository = fileStorageRepository;
            this.questionImageRepository = questionImageRepository;
        }

        public async Task<Question> AddQuestion(Question question)
        {
            question.PlainText = HtmlHelper.RemoveHtmlTags(question.Text);
            return await this.questionRepository.AddAsync(question);
        }

        public async Task<QuestionImage> AddQuestionImageFile(FileStorage fileStorage, Guid questionId)
        {
            var fileStorageRecord = await this.fileStorageRepository.AddAsync(fileStorage);

            QuestionImage questionImage = null;
            if (fileStorageRecord != null)
            {
                questionImage = await this.questionImageRepository.AddAsync(new QuestionImage
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

        public async Task<string> GetBase64QuestionImage(Guid questionId)
        {
            var fileStorage = await this.fileStorageRepository.GetByQuestionAsync(questionId);

            if (fileStorage == null)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToBase64String(fileStorage.Data);
            }
        }
    }
}
