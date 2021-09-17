using System;
using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;
using VASPChan.Interfaces;

namespace VASPChan.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDataContext context;

        public PostRepository(AppDataContext context)
        {
            this.context = context;
        }

        public PostListDTO GetAll(int ID)
        {
            Thread thread = context.Threads.Single(t => t.ThreadID == ID);

            return new PostListDTO
            {
                ThreadTitle = thread.Title,
                ThreadDescription = thread.Description,
                Posts = context.Posts
                    .Where(p => p.ThreadID == ID)
                    .Select(p =>
                        new PostMinimalDTO()
                        {
                            PostID = p.PostID,
                            Content = p.Content,
                        }
                    )
            };
        }

        public PostDTO Get(int ID)
        {
            return context.Posts.Select(p =>
                new PostDTO()
                {
                    PostID = p.PostID,
                    Content = p.Content,
                    Thread = p.Thread.Title,
                    ThreadID = p.ThreadID
                }).SingleOrDefault(p => p.ThreadID == ID);
        }

        public async Task<PostDTO> Create(Post post)
        {
            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return new PostDTO()
            {
                PostID = post.PostID,
                Content = post.Content,
            };
        }

        public void Delete(int ID)
        {
            var thread = context.Threads.FirstOrDefault(t => t.ThreadID == ID);

            if (thread == null)
            {
                throw new ArgumentException("No such thread", nameof(thread));
            }

            context.Threads.Remove(thread);
            context.SaveChanges();
        }
    }
}
