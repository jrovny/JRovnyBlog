using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRovnyBlog.Data.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("post_id")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Column("parent_comment_id")]
        public int? ParentCommentId { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("upvote_count")]
        public int UpvoteCount { get; set; }
        [Column("downvote_count")]
        public int DownvoteCount { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("user_ip")]
        public string UserIp { get; set; }
        [Column("user_email")]
        public string UserEmail { get; set; }
        [Column("email_hash")]
        public string EmailHash { get; set; }
        [Column("user_url")]
        public string UserUrl { get; set; }
        [Column("user_agent")]
        public string UserAgent { get; set; }
        [Column("is_anonymous")]
        public bool IsAnonymous { get; set; }
        [Column("remember_me")]
        public bool RememberMe { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        public Comment Parent { get; set; }
    }
}