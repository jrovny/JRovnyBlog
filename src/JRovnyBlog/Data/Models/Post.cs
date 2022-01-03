using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRovnyBlog.Data.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("slug")]
        public string Slug { get; set; }
        [Column("image")]
        public string Image { get; set; }
        // [Column("view_count")]
        // public int ViewCount { get; set; }
        [Column("published")]
        public bool Published { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}