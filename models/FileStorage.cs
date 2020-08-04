using System;

namespace models
{
    public class FileStorage
    {
        public Guid Id { get; set; }
        public string FileType { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
