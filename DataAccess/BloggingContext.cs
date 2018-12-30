using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bloggingEngine.DataAccess
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> config) : base(config)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required(ErrorMessage ="Your title cannot be empty.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Your post cannot be empty.")]
        public string Content { get; set; }
        [Required(ErrorMessage ="You must choose an author.")]

        public int AuthorId { get; set; }
        public DateTime CreatedAtAction { get; set; }
    }

    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        [Required(ErrorMessage ="Your comment cannot be empty.")]

        public string Content { get; set; }
        [Required(ErrorMessage ="You must choose an author.")]

        public int AuthorId { get; set; }
        public DateTime CreatedAtAction { get; set; }
    }

    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="You must choose a name.")]
        public string AuthorName { get; set; }
        public DateTime CreatedAtAction { get; set; }
    }
}