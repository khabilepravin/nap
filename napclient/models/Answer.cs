namespace models
{
    public class Answer
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
