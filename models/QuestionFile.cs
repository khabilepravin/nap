using System;

namespace models
{
    public class QuestionFile
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid FileId { get; set; }
    }
}
