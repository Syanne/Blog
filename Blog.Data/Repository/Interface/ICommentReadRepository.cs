using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface ICommentWriteRepository
    {
        Task AddComment(Comment comment);
        Task EditComment(Comment comment);
        Task DeleteComment(Comment comment);
    }
}
