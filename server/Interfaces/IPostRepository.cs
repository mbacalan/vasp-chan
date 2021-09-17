using System.Linq;
using System.Threading.Tasks;
using VASPChan.Models;

namespace VASPChan.Interfaces
{
    public interface IPostRepository
    {
        PostListDTO GetAll(int ID);
        PostDTO Get(int ID);
        Task<PostDTO> Create(Post post);
        void Delete(int ID);
    }
}
