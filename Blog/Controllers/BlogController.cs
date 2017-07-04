using Blog.Data.Entities;
using Blog.Data.Repository.Interface;
using Blog.Models;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostReadRepository postReadRepository;
        private readonly IPostWriteRepository postWriteRepository;
        private readonly ICommentWriteRepository commentWriteRepository;
        private readonly ICommentReadRepository commentReadRepository;
        private int ItemsPerPage = 5;

        public BlogController(IPostReadRepository postReadRepository,
                                IPostWriteRepository postWriteRepository,
                                ICommentWriteRepository commentWriteRepository,
                                ICommentReadRepository commentReadRepository)
        {
            this.postReadRepository = postReadRepository;
            this.postWriteRepository = postWriteRepository;
            this.commentWriteRepository = commentWriteRepository;
            this.commentReadRepository = commentReadRepository;
        }

        public async Task<ActionResult> CreateOrUpdatePost(long? id)
        {
            if (id.HasValue)
            {
                var post = await postReadRepository.GetPost(id.Value);
                return View(CreatePostViewModel(post));
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrUpdatePost(PostViewModel postModel)
        {
            var post = CreatePostInstance(postModel);

            if (post.PostId != default(Int64))
                await postWriteRepository.EditPost(post);
            else
                await postWriteRepository.AddPost(post);

            return RedirectToAction("ViewPost", new { id = post.PostId });
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(string content, long postId)
        {
            var comment = new Comment
            {
                PostId = postId,
                Content = content,
                IsBlocked = false,
                UserName = User.Identity.Name
            };

            await commentWriteRepository.AddComment(comment);

            return RedirectToAction("ViewPost", new { id = comment.PostId });
        }

        [HttpGet]
        public async Task<ActionResult> BlockComment(long commentId)
        {
            var comment = await commentReadRepository.GetComment(commentId);
            comment.IsBlocked = true;

            await commentWriteRepository.EditComment(comment);

            return RedirectToAction("ViewPost", new { id = comment.PostId });
        }

        // GET: Blog
        public async Task<ActionResult> Blog(int? page)
        {
            var posts = await postReadRepository.GetBlogPosts();
            return View(posts.Select(CreatePostViewModel).ToPagedList(page ?? 1, ItemsPerPage));
        }

        [HttpGet]
        public async Task<ActionResult> ViewPost(long? id)
        {
            if (id.HasValue)
            {
                var post = await postReadRepository.GetPost(id.Value);
                post.Comments = await commentReadRepository.GetCommentsByPostId(id.Value);
                return View(CreatePostViewModel(post));
            }

            return RedirectToAction("Blog");
        }

        private PostViewModel CreatePostViewModel(Post post)
        {
            return new PostViewModel
            {
                PostId = post.PostId,
                Comments = post.Comments,
                Content = post.Content,
                Title = post.Title,
                LastUpdateDate = post.LastUpdateDate
            };
        }

        private Post CreatePostInstance(PostViewModel post)
        {
            return new Post
            {
                PostId = post.PostId,
                Comments = post.Comments,
                Content = post.Content,
                Title = post.Title,
                LastUpdateDate = DateTime.Now
            };
        }
    }
}