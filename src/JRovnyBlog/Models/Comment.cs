using System;

namespace JRovnyBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string EmailHash { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}