using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IPostReadRepository
    {
        Task<Post[]> GetBlogPosts();
        Task<Post> GetPost(long id);
    }
}
