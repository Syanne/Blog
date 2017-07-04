using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.Data.Repository
{
    class PostReadRepository : IPostReadRepository
    {
        DbSet<Post> posts { get; set; }

        public PostReadRepository(DataContext dataContext)
        {
            posts = dataContext.Posts;
        }

        public async Task<Post[]> GetBlogPosts()
        {
            return await posts.ToArrayAsync();
        }

        public async Task<Post> GetPost(long id)
        {
            return await posts
                .FirstOrDefaultAsync(post => post.PostId == id);
        }
    }
}
