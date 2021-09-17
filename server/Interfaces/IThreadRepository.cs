using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;

namespace VASPChan.Interfaces
{
    public interface IThreadRepository
    {
        ThreadListDTO GetAll(string board);
        ThreadDTO Get(int ID);
        Task<ThreadDTO> Create(Thread thread);
        void Delete(int ID);
    }
}
