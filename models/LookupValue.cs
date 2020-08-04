using System;

namespace models
{
    public class LookupValue
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid GroupId { get; set; }
        public string Description { get; set; }
    }
}
