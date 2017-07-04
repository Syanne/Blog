using Blog.Data.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public virtual Comment[] Comments { get; set; }
    }
}
