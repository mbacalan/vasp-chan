using System.Collections.Generic;
using System.Linq;

namespace VASPChan.Models
{
    public class BoardDTO
    {
        public int BoardID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Threads { get; set; }
    }

    public class ThreadDTO
    {
        public int ThreadID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BoardID { get; set; }
        public string Board { get; set; }
        public List<int> Posts { get; set; }
    }

    public class ThreadMinimalDTO
    {
        public int ThreadID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> Posts { get; set; }
    }

    public class ThreadListDTO {
        public string BoardName { get; set; }
        public string BoardDescription { get; set; }
        public IQueryable<ThreadMinimalDTO> Threads { get; set; }
    }

    public class PostDTO
    {
        public int PostID { get; set; }
        public string Content { get; set; }
        public int ThreadID { get; set; }
        public string Thread { get; set; }
    }

    public class PostMinimalDTO {
        public int PostID { get; set; }
        public string Content { get; set; }
    }

    public class PostListDTO {
        public string ThreadTitle { get; set; }
        public string ThreadDescription { get; set; }
        public IQueryable<PostMinimalDTO> Posts { get; set; }
    }
}
