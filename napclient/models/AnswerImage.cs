using System;

namespace models
{
    public class AnswerImage
    {
        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public Guid FileId { get; set; }
    }
}
