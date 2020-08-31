using dataAccess.Repositories;
using logic.RequestModels;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace logic
{
    public class PracticeTestLogic : IPracticeTestLogic
    {
        private readonly IUserTestRecordRepository userTestRecordRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly ITestRepository testRepository;
        public PracticeTestLogic(IUserTestRecordRepository userTestRecordRepository,
                                IAnswerRepository answerRepository,
                                ITestRepository testRepository)
        {
            this.userTestRecordRepository = userTestRecordRepository;
            this.answerRepository = answerRepository;
            this.testRepository = testRepository;
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
                UserTestId = textAnswerRecord.UserTestId,
                AnswerText = textAnswerRecord.UserAnswerText
            });
        }

        //public async Task<Test> GetByUserTestIdAsync(Guid userTestId)
        //{
            //var test = await this.testRepository.GetByUserTestIdAsync(userTestId);

            //if(test != null)
            //{

            //}

//            Shuffler.Shuffle<List<Test>>(test.);

        //}
    }
}
