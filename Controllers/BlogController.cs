using System;
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
        
    [UrlActionFilter]
    [Route("blog")]
    [HttpGet()]
        public IActionResult Index()
        {
            var BlogPostListModel = new BlogPostList();

            var blogposts = 
    (
        from post in _bloggingContext.Posts
        join author in _bloggingContext.Authors
        on post.AuthorId equals author.AuthorId
        where post.PostId == post.PostId
        select new BlogPost()
        {
            PostId = post.PostId,
            Title = post.Title,
            Content = post.Content,
            CreatedAtAction = post.CreatedAtAction,
            AuthorName = author.AuthorName,
            AuthorId = post.AuthorId
        }
    ).OrderByDescending(c => c.CreatedAtAction).ToList();

            BlogPostListModel.BlogPosts = blogposts;
            return View(BlogPostListModel);
    }

    [UrlActionFilter]
    [Route("blog/comments")]
    [HttpGet()]
        public IActionResult Comments()
        {
            var comments = _bloggingContext.Comments.ToList();
            var CommentListModel = new CommentList();
            CommentListModel.Comments = comments;
            return View(CommentListModel);
        }
    [UrlActionFilter]
    [Route("blog/users")]
    [HttpGet()]
        public IActionResult Users()
        {
            var authors = _bloggingContext.Authors.ToList();
            var authorList = new AuthorList();
            authorList.Authors = authors;
            return View(authorList);
        }


    [UrlActionFilter]
    [Route("blog/post/{postId}/")]
    [HttpGet]
    public IActionResult Detail( [FromRoute] int postId )
    {
            var blogpost = _bloggingContext.Posts.Find(postId);
            var PostAuthor = _bloggingContext.Authors.Find(blogpost.AuthorId);
            var BlogPostModelItem = new BlogPostModel() {
                PostId = blogpost.PostId,
                Title = blogpost.Title,
                Content = blogpost.Content,
                AuthorId = blogpost.AuthorId,
                CreatedAtAction = blogpost.CreatedAtAction
            };
            var AuthorModelItem = new AuthorModel() {
                AuthorId = PostAuthor.AuthorId,
                AuthorName = PostAuthor.AuthorName,
            };
            PostView PostView = new PostView();
            PostView.Post = BlogPostModelItem;
            PostView.Author = AuthorModelItem;
            CommentViewList CommentViewList = new CommentViewList();

            // var comments = _bloggingContext.Comments.Where(c => c.PostId == postId).ToList();
            
            var comments = 
    (
        from comment in _bloggingContext.Comments
        join author in _bloggingContext.Authors
        on comment.AuthorId equals author.AuthorId
        where comment.PostId == postId
        select new CommentView()
        {
            CommentId = comment.CommentId,
            AuthorId = comment.AuthorId,
            AuthorName = author.AuthorName,
            Content = comment.Content,
            CreatedAtAction = comment.CreatedAtAction,
        }
    ).ToList();

            ViewModel DetailModel = new ViewModel(); 
            DetailModel.PostView = PostView;
            DetailModel.Comments = comments;
            CommentCreate CommentCreate = new CommentCreate();
            var AuthorList = _bloggingContext.Authors.ToList();
            CommentCreate.Authors = AuthorList;
            DetailModel.CommentCreate = CommentCreate;
            return View("Detail", DetailModel);
    }
    [UrlActionFilter]
    [Route("blog/post/{postId}/")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult NewComment( [FromRoute] int postId, [FromForm]CommentCreate commentCreate )
    {
            
            if (ModelState.IsValid)
            {
            var comments = _bloggingContext.Comments;
            comments.Add(new Comment
            {
                PostId = postId,
                AuthorId = commentCreate.Comment.AuthorId,
                Content = commentCreate.Comment.Content,
                CreatedAtAction = DateTime.Now
            });
            Console.WriteLine("TestId: "+ commentCreate.Comment.AuthorId + " TestContent: " + commentCreate.Comment.Content);
            
            _bloggingContext.SaveChanges();
            return RedirectToAction("Detail");
            }
        var PostCreate = new PostCreate(){
            
        };
        
        return this.Detail(postId);
        // return View("Detail");
        // return RedirectToAction("Detail");
    }
    [UrlActionFilter]
    [Route("blog/edit/{postId}/")]
    [HttpGet]
    public IActionResult Edit( [FromRoute] int postId )
    {
            var blogpost = _bloggingContext.Posts.Find(postId);
            var BlogPostModelItem = new BlogPostModel() {
                PostId = blogpost.PostId,
                Title = blogpost.Title,
                Content = blogpost.Content,
                AuthorId = blogpost.AuthorId,
                CreatedAtAction = blogpost.CreatedAtAction
            };
            return View("Edit", BlogPostModelItem);
    }
    [UrlActionFilter]
    [Route("blog/edit/{postId}/")]
    [HttpPost]
    public IActionResult SaveEdit( [FromRoute] int postId, [FromForm]Post post )
    {
        var blogpost = _bloggingContext.Posts.Find(postId);
        blogpost.Title = post.Title;
        blogpost.Content = post.Content;
        
        if (ModelState.IsValid)
        {
            _bloggingContext.SaveChanges();
        return RedirectToAction("Detail");
        
        }

        return this.Edit(postId);
    }
    [UrlActionFilter]
    [Route("blog/delete/{postId}/")]
    [HttpGet]
    public IActionResult DeletePost( [FromRoute] int postId, [FromForm]Post post )
    {
        var blogpost = _bloggingContext.Posts.Find(postId);

        // remove all comments of post (cleanup)
        var comments = _bloggingContext.Comments;
        var postComments = comments.Where(p => p.PostId == postId).ToList();
        foreach (var postComment in postComments){
            comments.Remove(postComment);
        }

        _bloggingContext.Posts.Remove(blogpost);
        _bloggingContext.SaveChanges();
        return RedirectToAction("Index");
    }


    [UrlActionFilter]
    [Route("blog/deletecomment/{commentId}/")]
    [HttpGet]
    public IActionResult DeleteComment( [FromRoute] int commentId, int postId )
    {
        var comment = _bloggingContext.Comments.Find(commentId);
        _bloggingContext.Comments.Remove(comment);
        System.Console.WriteLine(postId);
        _bloggingContext.SaveChanges();
        return RedirectToAction("post", "blog", new {@id=postId});
    }


    [UrlActionFilter]
    [Route("blog/deleteauthor/{authorId}/")]
    [HttpGet]
    public IActionResult DeleteAuthor( [FromRoute] int authorId )
    {
        var author = _bloggingContext.Authors.Find(authorId);
        var posts = _bloggingContext.Posts;

        // remove all posts of user (cleanup)
        var authorPosts = posts.Where(p => p.AuthorId == authorId).ToList();
        foreach (var authorPost in authorPosts){
            posts.Remove(authorPost);
        }


        // remove all comments of user (cleanup)
        var comments = _bloggingContext.Comments;
        var authorComments = comments.Where(p => p.AuthorId == authorId).ToList();
        foreach (var authorComment in authorComments){
            comments.Remove(authorComment);
        }


        _bloggingContext.Authors.Remove(author); // remove user
        _bloggingContext.SaveChanges();
        return RedirectToAction("Users");
    }


    [UrlActionFilter]
    [Route("blog/create/")]
    [HttpGet]
    public IActionResult Create()
    {
        var PostCreate = new PostCreate(){

        };
        var AuthorList = _bloggingContext.Authors.ToList();
        PostCreate.Authors = AuthorList;
        return View("Create", PostCreate);
    }

    [UrlActionFilter]
    [Route("blog/create/")]
    [HttpPost]
    public IActionResult NewPost( [FromForm]Post post )
    {
        
        _bloggingContext.Posts.Add(new Post
            {
                AuthorId = post.AuthorId,
                Title = post.Title,
                Content = post.Content,
                CreatedAtAction = DateTime.Now
            });
        if (ModelState.IsValid)
        {
        _bloggingContext.SaveChanges();
        return RedirectToAction("Index");
        }

        return this.Create();
    }

    [UrlActionFilter]
    [Route("blog/adduser/")]
    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }

    [UrlActionFilter]
    [Route("blog/adduser/")]
    [HttpPost]
    public IActionResult NewUser([FromForm]Author author)
    {
        _bloggingContext.Authors.Add(new Author
        {
            AuthorName = author.AuthorName,
            CreatedAtAction = DateTime.Now
        });
        _bloggingContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [UrlActionFilter]
    [Route("blog/author/{authorId}")]
    [HttpGet()]
        public IActionResult Author([FromRoute] int authorId)
        {
            var author = _bloggingContext.Authors.Find(authorId);
            var authorPostsModel = new AuthorPostsModel() {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName,
            };
            var posts = _bloggingContext.Posts;

            // remove all posts of user (cleanup)
             var blogposts = 
    (
        from post in _bloggingContext.Posts
        where post.AuthorId == authorId
        select new BlogPost()
        {
            PostId = post.PostId,
            Title = post.Title,
            Content = post.Content,
            CreatedAtAction = post.CreatedAtAction,
            AuthorName = author.AuthorName,
            AuthorId = post.AuthorId
        }
    ).OrderByDescending(c => c.CreatedAtAction).ToList();
            authorPostsModel.BlogPosts = blogposts;
            return View(authorPostsModel);
        }

    }
}