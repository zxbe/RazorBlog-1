using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domains
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
