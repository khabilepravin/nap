using System;

namespace models
{
    public class Explanation
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string TextExplanation { get; set; }
        public string ExternalLink { get; set; }
        public string LinkType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CreatedByUser { get; set; }
        public Guid ModifiedByUser { get; set; }
    }
}
