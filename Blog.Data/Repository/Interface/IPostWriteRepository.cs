using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IPostWriteRepository
    {
        Task AddPost(Post post);
        Task DeletePost(Post post);
        Task EditPost(Post post);
    }
}
