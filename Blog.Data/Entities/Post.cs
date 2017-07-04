using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Entities
{
    public class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public virtual Comment[] Comments { get; set; }
    }
}
