﻿using System;

namespace models
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public string Subject { get; set; }
        public int DurationMinutes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CreatedByUser { get; set; }
        public Guid ModifiedByUser { get; set; }
        public string Status { get; set; }
        public string DifficultyLevel { get; set; }
        public string Year { get; set; }
        public string TestType { get; set; }
        public string PublishedStatus { get; set; }
    }
}
