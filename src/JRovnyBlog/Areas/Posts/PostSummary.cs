using System;

namespace JRovnyBlog.Areas.Posts
{
    public class PostSummary
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public int CommentCount { get; set; }
        public int UpvoteCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}