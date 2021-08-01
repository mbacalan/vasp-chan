using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;

namespace VASPChan.Interfaces
{
    public interface IBoardRepository
    {
        IQueryable<BoardDTO> GetAll();
        Task<BoardDTO> Get(int ID);
        Task<BoardDTO> Create(Board board);
        void Delete(int ID);
    }
}
