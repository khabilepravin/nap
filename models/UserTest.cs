using System;

namespace models
{
    public class UserTest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string Mode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Status { get; set; }
        public int ShuffleSeed { get; set; }
    }
}
