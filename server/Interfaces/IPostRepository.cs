using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;

namespace VASPChan.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<PostDTO> GetAll();
        PostDTO Get(int ID);
        Task<PostDTO> Create(Post post);
        void Delete(int ID);
    }
}
