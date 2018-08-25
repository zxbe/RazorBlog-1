using System;
using System.Collections.Generic;

namespace Infrastructure.Domains
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public ICollection<PostTag> Tags { get; set; } = new List<PostTag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Category Category { get; set; } = new Category();
    }
}
