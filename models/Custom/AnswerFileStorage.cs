using System;

namespace models.Custom
{
    public class AnswerFileStorage : FileStorage
    {
        public Guid AnswerId { get; set; }
        public string Base64Data { get; set; }
    }
}
