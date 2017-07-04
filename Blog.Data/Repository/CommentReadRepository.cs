using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Blog.Data.Repository
{
    class CommentReadRepository : ICommentReadRepository
    {
        DbSet<Comment> comments { get; set; }

        public CommentReadRepository(DataContext dataContext)
        {
            comments = dataContext.Comments;
        }

        public Task<Comment> GetComment(long id)
        {
            return comments
                    .FirstOrDefaultAsync(comment => comment.CommentId == id);
        }
        
        public Task<Comment[]> GetCommentsByPostId(long postId)
        {
            return comments
                .Where(comment => comment.PostId == postId)
                .Where(comment => !comment.IsBlocked)
                .ToArrayAsync();
        }
    }
}
