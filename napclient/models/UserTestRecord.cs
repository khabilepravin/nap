using System;

namespace models
{
    public class UserTestRecord
    {
        public Guid Id { get; set; }
        public Guid UserTestId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
