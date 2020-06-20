using System;

namespace models
{
    public class QuestionImage
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid FileId { get; set; }
    }
}
