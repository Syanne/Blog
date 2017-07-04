using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    public class CommentViewModel
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public bool IsBlocked { get; set; }
        public long PostId { get; set; }
    }
}
