using System;
using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;
using VASPChan.Interfaces;

namespace VASPChan.Services
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly AppDataContext context;

        public ThreadRepository(AppDataContext context)
        {
            this.context = context;
        }

        public IQueryable<ThreadDTO> GetAll()
        {
            return context.Threads.Select(t =>
                new ThreadDTO()
                {
                    ThreadID = t.ThreadID,
                    Title = t.Title,
                    Description = t.Description,
                    Board = t.Board.Name,
                    BoardID = t.BoardID,
                    Posts = t.Posts.Select(p => p.PostID).ToList<int>()
                }
            );
        }

        public ThreadDTO Get(int ID)
        {
            return context.Threads.Select(t =>
                new ThreadDTO()
                {
                    ThreadID = t.ThreadID,
                    Title = t.Title,
                    Description = t.Description,
                    Board = t.Board.Name,
                    BoardID = t.BoardID,
                    Posts = t.Posts.Select(p => p.PostID).ToList<int>()
                }).SingleOrDefault(t => t.ThreadID == ID);
        }

        public async Task<ThreadDTO> Create(Thread thread)
        {
            context.Threads.Add(thread);
            await context.SaveChangesAsync();

            return new ThreadDTO()
            {
                ThreadID = thread.ThreadID,
                Title = thread.Title,
                Description = thread.Description,
                Board = thread.Board.Name,
                BoardID = thread.BoardID
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
