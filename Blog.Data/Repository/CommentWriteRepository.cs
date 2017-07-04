using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.Data.Repository
{
    class CommentWriteRepository : ICommentWriteRepository
    {
        DataContext dataContext { get; set; }
        DbSet<Comment> comments { get; set; }

        public CommentWriteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            comments = dataContext.Comments;
        }

        public Task AddComment(Comment comment)
        {
            comments.Add(comment);
            return dataContext.SaveChangesAsync();
        }

        public Task DeleteComment(Comment comment)
        {
            comments.Remove(comment);
            return dataContext.SaveChangesAsync();
        }

        public async Task EditComment(Comment comment)
        {
            var existComment = await dataContext
                                   .Comments
                                   .SingleOrDefaultAsync(b => b.CommentId == comment.CommentId);

            if (existComment != null)
            {
                existComment = comment;
                dataContext.SaveChanges();
            }
        }
    }
}
