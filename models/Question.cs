﻿using System;

namespace models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string QuestionType { get; set; }
        public Guid TestId { get; set; }
        public int Sequence { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CreatedByUser { get; set; }
        public Guid ModifiedByUser { get; set; }
        public string Status { get; set; }
        public string DifficultyLevel { get; set; }
        public Guid FileId { get; set; }
        public string PlainText { get; set; }
    }
}
