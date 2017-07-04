using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserReadRepository
    {
        Task<User> GetUser(User user);
    }
}
