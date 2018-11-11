using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace bloggingEngine.DataAccess
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> config) : base(config)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }
        public DateTime CreatedAtAction { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAtAction { get; set; }
    }
}