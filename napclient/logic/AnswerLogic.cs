using dataAccess.Repositories;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public class AnswerLogic : IAnswerLogic
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IFileStorageRepository fileStorageRepository;
        private readonly IAnswerImageRepository answerImageRepository;
        public AnswerLogic(IAnswerRepository answerRepository,
                            IFileStorageRepository fileStorageRepository,
                            IAnswerImageRepository answerImageRepository)
        {
            this.answerRepository = answerRepository;
            this.fileStorageRepository = fileStorageRepository;
            this.answerImageRepository = answerImageRepository;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            answer.PlainText = HtmlHelper.RemoveHtmlTags(answer.Text);
            return await this.answerRepository.AddAsync(answer);
        }

        public async Task<AnswerImage> AddImageAnswer(FileStorage fileStorage, Guid answerId)
        {
            var fileStorageRecord = await this.fileStorageRepository.AddAsync(fileStorage);
            AnswerImage answerImageRecord = null;
            if (fileStorageRecord != null)
            {
                answerImageRecord = await this.answerImageRepository.AddAsync(new AnswerImage
                {
                    AnswerId = answerId,
                    FileId = fileStorageRecord.Id
                });
            }
            else
            {
                throw new Exception("Failed to store image file");
            }

            return answerImageRecord;
        }
    }
}
