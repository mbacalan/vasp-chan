using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VASPChan.Models;
using VASPChan.Interfaces;

namespace VASPChan.Services
{
    public class BoardRepository: IBoardRepository
    {
        private readonly AppDataContext context;

        public BoardRepository(AppDataContext context)
        {
            this.context = context;
        }

        public IQueryable<BoardDTO> GetAll()
        {
            return context.Boards.Select(b =>
                new BoardDTO()
                {
                    BoardID = b.BoardID,
                    Name = b.Name,
                    Description = b.Description,
                    Threads = b.Threads.Select(t => t.ThreadID).ToList<int>()
                }
            );
        }

        public async Task<BoardDTO> Get(int ID)
        {
            return await context.Boards.Select(b =>
                new BoardDTO()
                {
                    BoardID = b.BoardID,
                    Name = b.Name,
                    Description = b.Description,
                    Threads = b.Threads.Select(t => t.ThreadID).ToList<int>()
                }).SingleOrDefaultAsync(b => b.BoardID == ID);
        }

        public async Task<BoardDTO> Create(Board board)
        {
            context.Boards.Add(board);
            await context.SaveChangesAsync();

            return new BoardDTO()
            {
                BoardID = board.BoardID,
                Name = board.Name,
                Description = board.Description,
            };
        }

        public void Delete(int ID)
        {
            var board = context.Boards.FirstOrDefault(b => b.BoardID == ID);

            if (board == null)
            {
                throw new ArgumentException("No such board", nameof(board));
            }

            context.Boards.Remove(board);
            context.SaveChanges();
        }
    }
}
