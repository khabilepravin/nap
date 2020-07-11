using System;

namespace logic.RequestModels
{
    public class TextAnswerRecord
    {
        public Guid UserTestId { get; set; }
        public Guid QuestionId { get; set; }
        public string UserAnswerText { get; set; }        
    }
}
