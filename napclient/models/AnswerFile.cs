using System;

namespace models
{
    public class AnswerFile
    {
        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public Guid FileId { get; set; }
    }
}
