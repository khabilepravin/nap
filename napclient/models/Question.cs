using System;

namespace models
{
    public class Question
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string QuestionType { get; set; }
        public Int16 Sequence { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
