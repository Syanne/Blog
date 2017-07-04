using Blog.Data.Entities;
using System.Data.Entity;

namespace Blog.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DataContext() : base("Blog") { }
    }
}