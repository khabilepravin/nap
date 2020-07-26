using dataAccess.Repositories;
using externalServices;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public class AnswerLogic : IAnswerLogic
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IFileStorageRepository fileStorageRepository;
        private readonly IAnswerFileRepository answerImageRepository;
        private readonly ITextToSpeech textToSpeech;
        public AnswerLogic(IAnswerRepository answerRepository,
                            IFileStorageRepository fileStorageRepository,
                            IAnswerFileRepository answerImageRepository,
                            ITextToSpeech textToSpeech)
        {
            this.answerRepository = answerRepository;
            this.fileStorageRepository = fileStorageRepository;
            this.answerImageRepository = answerImageRepository;
            this.textToSpeech = textToSpeech;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            answer.PlainText = HtmlHelper.RemoveHtmlTags(answer.Text);
            return await this.answerRepository.AddAsync(answer);
        }

        public async Task<AnswerFile> AddImageAnswer(FileStorage fileStorage, Guid answerId)
        {
            var fileStorageRecord = await this.fileStorageRepository.AddAsync(fileStorage);
            AnswerFile answerImageRecord = null;
            if (fileStorageRecord != null)
            {
                answerImageRecord = await this.answerImageRepository.AddAsync(new AnswerFile
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

        public async Task AddAnswerAudioFile(Guid answerId, string answerPlainText)
        {
            var audioFileData = this.textToSpeech.ConvertTextToSpeech(answerPlainText);

            if (audioFileData != null)
            {
                var fileStorage = await this.fileStorageRepository.AddAsync(new FileStorage
                {
                    Data = audioFileData,
                    Extension = ".mp3",
                    FileType = "audio/mpeg",
                    Name = $"question_{answerId}"
                });

                if (fileStorage != null)
                {
                    await this.answerImageRepository.AddAsync(new AnswerFile
                    {
                        FileId = fileStorage.Id,
                        AnswerId = answerId
                    });
                }
            }
        }
    }
}
