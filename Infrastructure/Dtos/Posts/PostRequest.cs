using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.Posts
{
    public class PostRequest
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Permalink { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public long CurrentUser { get; set; }
    }
}
