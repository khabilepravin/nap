using System;

namespace models
{
    public class Test
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
