using Blog.Data.Entities;
using System.Threading.Tasks;

namespace Blog.Data.Repository.Interface
{
    public interface IUserWriteRepository
    {
        Task AddUser(User user);
        Task DeleteUser(User user);
    }
}
