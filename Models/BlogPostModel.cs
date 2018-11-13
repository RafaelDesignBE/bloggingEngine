
using System;
using System.Collections.Generic;
using bloggingEngine.DataAccess;

  public class BlogPostModel
  {
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public DateTime CreatedAtAction { get; set; }
  }

  public class PostView {
    public BlogPostModel Post { get; set; }
    public AuthorModel Author { get; set; }
  }

  public class PostViewList
  {
    public List<PostView> Posts { get; set; }
  }

  public class BlogPostList
  {
    public List<Post> BlogPosts { get; set; }
  }

  public class CommentList
  {
    public List<Comment> Comments { get; set; }
  }

public class AuthorList
  {
    public List<Author> Authors { get; set; }
  }

public class CommentModel
  {
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public DateTime CreatedAtAction { get; set; }
  }

public class CommentViewList
  {
    public List<Comment> Comments { get; set; }
  }
  // public class CommentView
  // {
  //   public CommentModel Comment { get; set; }
  //   public AuthorModel Author { get; set; }
  // }

  public class CommentView
  {
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public DateTime CreatedAtAction { get; set; }
  }

  public class AuthorModel
  {
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
  }

  public class ViewModel  
{  
    public PostView PostView { get; set; }  
    public List<CommentView> Comments { get; set; }  
    public CommentModel CommentModel { get; set; }
}  