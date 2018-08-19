﻿namespace Infrastructure.Domains
{
    public class PostTag
    {
        public long PostId { get; set; }
        public Post Post { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
