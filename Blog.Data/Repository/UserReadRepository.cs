using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    class UserReadRepository : IUserReadRepository
    {
        DbSet<User> users { get; set; }

        public UserReadRepository(DataContext dataContext)
        {
            users = dataContext.Users;
        }

        public async Task<User> GetUser(User user)
        {
            return await users.FirstOrDefaultAsync(existUser => 
                                existUser.Login == user.Login
                                && existUser.Password == user.Password);
        }
    }
}
