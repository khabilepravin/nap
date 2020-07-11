using dataAccess.Repositories;
using logic.RequestModels;
using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public class PracticeTestLogic : IPracticeTestLogic
    {
        private readonly IUserTestRecordRepository userTestRecordRepository;
        private readonly IAnswerRepository answerRepository;
        public PracticeTestLogic(IUserTestRecordRepository userTestRecordRepository,
                                IAnswerRepository answerRepository)
        {
            this.userTestRecordRepository = userTestRecordRepository;
            this.answerRepository = answerRepository;
        }

        public async Task RecordTextAnswer(TextAnswerRecord textAnswerRecord)
        {
            var questionAnswers = await this.answerRepository.GetByQuestionIdAsync(textAnswerRecord.QuestionId);

            Answer selectedAnswer = null;

            foreach(var answer in questionAnswers)
            {
                if(string.Compare(answer.Text, textAnswerRecord.UserAnswerText, ignoreCase:false) == 0)
                {
                    selectedAnswer = answer;
                    break;
                }
                else
                {
                    continue;
                }
            }

            await this.userTestRecordRepository.AddAsync(new models.UserTestRecord
            {
                AnswerId = selectedAnswer == null ? Guid.Empty :  selectedAnswer.Id,
                IsCorrect = selectedAnswer == null ? false : selectedAnswer.IsCorrect,
                QuestionId = textAnswerRecord.QuestionId,
                UserTestId = textAnswerRecord.UserTestId
            });
        }
    }
}
