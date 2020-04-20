using System;

namespace models
{
    public class Test
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Int16 Sequence { get; set; }
        public string Subject { get; set; }
        public Int16 DurationMinutes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
