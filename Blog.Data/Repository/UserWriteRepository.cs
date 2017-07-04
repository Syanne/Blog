using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.Data.Repository
{
    class UserWriteRepository : IUserWriteRepository
    {
        DataContext dataContext { get; set; }
        DbSet<User> users { get; set; }

        public UserWriteRepository(DataContext dataContext)
        {
            users = dataContext.Users;
            this.dataContext = dataContext;
        }

        public Task AddUser(User user)
        {
            users.Add(user);
            return dataContext.SaveChangesAsync();
        }

        public Task DeleteUser(User user)
        {
            users.Remove(user);
            return dataContext.SaveChangesAsync();
        }
    }
}
