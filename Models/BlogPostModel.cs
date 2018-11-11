
using System;
using System.Collections.Generic;
using bloggingEngine.DataAccess;

  public class BlogPostModel
  {
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAtAction { get; set; }
  }

  public class BlogPostList
  {
    public List<Post> BlogPosts { get; set; }
  }

  public class CommentList
  {
    public List<Comment> Comments { get; set; }
  }


public class CommentModel
  {
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAtAction { get; set; }
  }

  public class ViewModel  
{  
    public BlogPostModel Post { get; set; }  
    public List<Comment> Comments { get; set; }  
    public CommentModel CommentModel { get; set; }
}  