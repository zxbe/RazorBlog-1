using System;

namespace Infrastructure.Domains
{
    public class Comment
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
