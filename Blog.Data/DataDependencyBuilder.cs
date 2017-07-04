using Autofac;
using Blog.Data.Repository;
using Blog.Data.Repository.Interface;

namespace Blog.Data
{
    public class DataDependencyBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostReadRepository>()
                .As<IPostReadRepository>();

            builder.RegisterType<PostWriteRepository>()
                .As<IPostWriteRepository>();

            builder.RegisterType<UserReadRepository>()
                .As<IUserReadRepository>();

            builder.RegisterType<UserWriteRepository>()
                .As<IUserWriteRepository>();

            builder.RegisterType<CommentWriteRepository>()
                .As<ICommentWriteRepository>();

            builder.RegisterType<CommentReadRepository>()
                .As<ICommentReadRepository>();
        }
    }
}