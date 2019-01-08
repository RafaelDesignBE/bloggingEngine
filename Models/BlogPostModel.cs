
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bloggingEngine.DataAccess;

  public class BlogPostModel
  {
    public int PostId { get; set; }
    [Required(ErrorMessage ="Your title cannot be empty.")]
    public string Title { get; set; }
    [Required(ErrorMessage ="Your post cannot be empty.")]
    public string Content { get; set; }
    [Required(ErrorMessage ="You must choose an author.")]
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

  public class BlogPost {
    public int PostId { get; set; }
    [Required(ErrorMessage ="Your title cannot be empty.")]
    public string Title { get; set; }
    [Required(ErrorMessage ="Your post cannot be empty.")]
    public string Content { get; set; }
    public DateTime CreatedAtAction { get; set; }
    [Required(ErrorMessage ="You must choose an author.")]
    public string AuthorName { get; set; }
    public int AuthorId { get; set; }
  }

  public class BlogPostList
  {
    public List<BlogPost> BlogPosts { get; set; }
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
    [Required(ErrorMessage ="Your comment cannot be empty.")]
    public string Content { get; set; }
    [Required(ErrorMessage ="You must choose an author.")]
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
    [Required]
    public string Content { get; set; }
    [Required]
    public string AuthorName { get; set; }
    public int AuthorId { get; set; }    
    public DateTime CreatedAtAction { get; set; }
  }

  public class AuthorModel
  {
    public int AuthorId { get; set; }
    [Required(ErrorMessage ="You must choose a name.")]
    public string AuthorName { get; set; }
  }

  public class AuthorPostsModel
  {
    public int AuthorId { get; set; }
    [Required(ErrorMessage ="You must choose a name.")]
    public string AuthorName { get; set; }

    public List<BlogPost> BlogPosts { get; set; }
  }

  public class ViewModel  
{  
    public PostView PostView { get; set; }  
    public List<CommentView> Comments { get; set; }  
    public CommentCreate CommentCreate { get; set; }
}  

public class PostCreate
{
  [Required(ErrorMessage ="Your post cannot be empty.")]
  public BlogPost Post { get; set; }
  [Required(ErrorMessage ="You must choose an author.")]
  public List<Author> Authors { get; set; }
}

public class CommentCreate
{
  [Required(ErrorMessage ="Your comment cannot be empty.")]
  public CommentModel Comment { get; set; }
  public List<Author> Authors { get; set; }
}