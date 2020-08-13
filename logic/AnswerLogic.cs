using dataAccess.Repositories;
using externalServices;
using logic.ResponseModels;
using models;
using models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logic
{
    public class AnswerLogic : IAnswerLogic
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IFileStorageRepository fileStorageRepository;
        private readonly IAnswerFileRepository answerFileRepository;
        private readonly ITextToSpeech textToSpeech;
        public AnswerLogic(IAnswerRepository answerRepository,
                            IFileStorageRepository fileStorageRepository,
                            IAnswerFileRepository answerImageRepository,
                            ITextToSpeech textToSpeech)
        {
            this.answerRepository = answerRepository;
            this.fileStorageRepository = fileStorageRepository;
            this.answerFileRepository = answerImageRepository;
            this.textToSpeech = textToSpeech;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            answer.PlainText = HtmlHelper.RemoveHtmlTags(answer.Text);
            var answerRecord = await this.answerRepository.AddAsync(answer);
            if(answerRecord != null)
            {
                await this.AddAnswerAudioFile(answerRecord.Id, answerRecord.PlainText);
            }
            return answerRecord;
        }

        public async Task<Answer> UpdateAnswer(Answer answer, FileStorage imageData)
        {
            answer.PlainText = HtmlHelper.RemoveHtmlTags(answer.Text);
            var answerRecord = await this.answerRepository.UpdateAsync(answer);

            // Update answer audio file
            var answerAudio = await this.fileStorageRepository.GetByAnswerAsync(answer.Id, new List<string>() { "audio/mpeg" });
            var answerImage = await this.fileStorageRepository.GetByAnswerAsync(answer.Id, new List<string>() { "image/png", "image/jpeg" });

            if(answerAudio == null)
            {
                // Add it
                await AddAnswerAudioFile(answer.Id, answer.PlainText);
            }
            else
            {
                // Update it
                await UpdateAnswerAudioFile(answer.Id, answer.PlainText, answerAudio);
            }

            if (imageData != null)
            {
                if (answerImage == null)
                {
                    await this.fileStorageRepository.AddAsync(imageData);
                }
                else
                {
                    imageData.Id = answerImage.Id;
                    await this.fileStorageRepository.UpdateAsync(imageData);
                }
            }

            return answer;            
        }

        public async Task<AnswerFile> AddImageAnswer(FileStorage fileStorage, Guid answerId)
        {
            var fileStorageRecord = await this.fileStorageRepository.AddAsync(fileStorage);
            AnswerFile answerImageRecord = null;
            if (fileStorageRecord != null)
            {
                answerImageRecord = await this.answerFileRepository.AddAsync(new AnswerFile
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
                    await this.answerFileRepository.AddAsync(new AnswerFile
                    {
                        FileId = fileStorage.Id,
                        AnswerId = answerId
                    });
                }
            }
        }

        public async Task UpdateAnswerAudioFile(Guid answerId, string answerPlainText, FileStorage answerAudio)
        {
            var audioFileData = this.textToSpeech.ConvertTextToSpeech(answerPlainText);
            if (audioFileData == null)
            {
                throw new Exception("Failed to convert using speech to text external service");
            }
            else
            {
                answerAudio.Data = audioFileData;
                await this.fileStorageRepository.UpdateAsync(answerAudio);
            }
        }

        public async Task<FileResponse> GetBase64AnswerAudio(Guid answerId)
        {
            var fileStorage = await fileStorageRepository.GetByAnswerAsync(answerId, new List<string> { "audio/mpeg" });

            if (fileStorage == null)
            {
                return null;
            }
            else
            {
                return new FileResponse { FileType = fileStorage.FileType, Base64Data = Convert.ToBase64String(fileStorage.Data) };
            }
        }

        public async Task<FileResponse> GetBase64AnswerImage(Guid answerId)
        {
            var fileStorage = await this.fileStorageRepository.GetByAnswerAsync(answerId, new List<string>() { "image/png", "image/jpeg" });

            if (fileStorage == null)
            {
                return null;
            }
            else
            {
                return new FileResponse { FileType = fileStorage.FileType, Base64Data = Convert.ToBase64String(fileStorage.Data) };
            }
        }
        public async Task<IEnumerable<AnswerFileStorage>> GetBase64AnswersImages(string comaSeperatedAnswerIds)
        {
            var stringAnswerIds = comaSeperatedAnswerIds.Split(',').ToList<string>();
            var answerGuids = (from i in stringAnswerIds
                               select new Guid(i)).ToList<Guid>();

            var imageFiles = await this.fileStorageRepository.GetByAnswerListAsync(answerGuids, new List<string> { "image/png", "image/jpeg" });

            if(imageFiles != null)
            {
               foreach(var answerFile in imageFiles)
                {
                    answerFile.Base64Data = Convert.ToBase64String(answerFile.Data);
                }   
            }

            return imageFiles;
        }
    }
}
