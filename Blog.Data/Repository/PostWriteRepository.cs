using Blog.Data.Repository.Interface;
using System;
using Blog.Data.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.Data.Repository
{
    class PostWriteRepository : IPostWriteRepository
    {
        DataContext dataContext { get; set; }
        DbSet<Post> posts { get; set; }

        public PostWriteRepository(DataContext dataContext)
        {
            posts = dataContext.Posts;
            this.dataContext = dataContext;
        }

        public Task AddPost(Post post)
        {
            posts.Add(post);
            return dataContext.SaveChangesAsync();
        }

        public Task DeletePost(Post post)
        {
            posts.Remove(post);
            return dataContext.SaveChangesAsync();
        }

        public async Task EditPost(Post post)
        {
            var existPost = await posts
                                   .SingleOrDefaultAsync(b => b.PostId == post.PostId);

            if (existPost != null)
            {
                existPost = post;
                dataContext.SaveChanges();
            }
        }
    }
}
