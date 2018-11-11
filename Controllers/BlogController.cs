using System;
using bloggingEngine.Models;
using bloggingEngine.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace bloggingEngine.Controllers
{
    public class BlogController : Controller
    {
        private BloggingContext _bloggingContext;

        public BlogController(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

    [Route("blog")]
    [HttpGet()]
        public IActionResult Index()
        {
            var blogposts = _bloggingContext.Posts.ToList();
            var BlogPostListModel = new BlogPostList();
            BlogPostListModel.BlogPosts = blogposts;
            return View(BlogPostListModel);
        }
    
    [Route("blog/comments")]
    [HttpGet()]
        public IActionResult Comments()
        {
            var comments = _bloggingContext.Comments.ToList();
            var CommentListModel = new CommentList();
            CommentListModel.Comments = comments;
            return View(CommentListModel);
        }

    [Route("blog/post/{postId}/")]
    [HttpGet]
    public IActionResult Detail( [FromRoute] int postId )
    {
            var blogpost = _bloggingContext.Posts.Find(postId);
            var BlogPostModelItem = new BlogPostModel() {
                PostId = blogpost.PostId,
                Title = blogpost.Title,
                Content = blogpost.Content,
                Author = blogpost.Author,
                CreatedAtAction = blogpost.CreatedAtAction
            };
            var comments = _bloggingContext.Comments.Where(c => c.PostId == postId).ToList();
            ViewModel DetailModel = new ViewModel(); 
            DetailModel.Post = BlogPostModelItem;
            DetailModel.Comments = comments;
            return View(DetailModel);
    }

    [Route("blog/post/{postId}/")]
    [HttpPost]
    public IActionResult NewComment( [FromRoute] int postId, [FromForm]Comment comment )
    {
            var comments = _bloggingContext.Comments;
            comments.Add(new Comment
            {
                PostId = postId,
                Author = comment.Author,
                Content = comment.Content,
                CreatedAtAction = DateTime.Now
            });
            _bloggingContext.SaveChanges();
            
            return RedirectToAction("Detail");
    }

    [Route("blog/edit/{postId}/")]
    [HttpGet]
    public IActionResult Edit( [FromRoute] int postId )
    {
            var blogpost = _bloggingContext.Posts.Find(postId);
            var BlogPostModelItem = new BlogPostModel() {
                PostId = blogpost.PostId,
                Title = blogpost.Title,
                Content = blogpost.Content,
                Author = blogpost.Author,
                CreatedAtAction = blogpost.CreatedAtAction
            };
            return View(BlogPostModelItem);
    }

    [Route("blog/edit/{postId}/")]
    [HttpPost]
    public IActionResult SaveEdit( [FromRoute] int postId, [FromForm]Post post )
    {
        var blogpost = _bloggingContext.Posts.Find(postId);
        blogpost.Title = post.Title;
        blogpost.Content = post.Content;
        _bloggingContext.SaveChanges();
        return RedirectToAction("Detail");
    }

    [Route("blog/delete/{postId}/")]
    [HttpGet]
    public IActionResult DeletePost( [FromRoute] int postId, [FromForm]Post post )
    {
        var blogpost = _bloggingContext.Posts.Find(postId);
        _bloggingContext.Posts.Remove(blogpost);
        _bloggingContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [Route("blog/create/")]
    [HttpGet]
    public IActionResult CreatePost( [FromRoute] int postId )
    {
            return View("Create");
    }


    [Route("blog/create/")]
    [HttpPost]
    public IActionResult NewPost( [FromForm]Post post )
    {
        _bloggingContext.Posts.Add(new Post
            {
                Author = post.Author,
                Title = post.Title,
                Content = post.Content,
                CreatedAtAction = DateTime.Now
            });
        _bloggingContext.SaveChanges();
        return RedirectToAction("Index");
    }

    }
}