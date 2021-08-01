using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VASPChan.Models
{
    public class Board
    {
        public int BoardID { get; set; }

        [MaxLength(3)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        public List<Thread> Threads { get; set; }
    }

    public class Thread
    {
        public int ThreadID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
        public int BoardID { get; set; }
        public Board Board { get; set; }
    }

    public class Post
    {
        public int PostID { get; set; }

        [Required]
        public string Content { get; set; }

        public int ThreadID { get; set; }
        public Thread Thread { get; set; }
    }
}
