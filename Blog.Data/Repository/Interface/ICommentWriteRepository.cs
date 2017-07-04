using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface ICommentReadRepository
    {
        Task<Comment> GetComment(long id);
        Task<Comment[]> GetCommentsByPostId(long postId);
    }
}
