using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Entities
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public bool IsBlocked { get; set; }
        public long PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
