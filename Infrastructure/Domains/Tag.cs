using System.Collections.Generic;

namespace Infrastructure.Domains
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }

        public ICollection<PostTag> Posts { get; set; } = new List<PostTag>();
    }
}
