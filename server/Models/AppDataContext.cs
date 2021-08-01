using Microsoft.EntityFrameworkCore;
using VASPChan.Models;

namespace VASPChan.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Boards").HasMany(b => b.Threads).WithOne(t => t.Board);
            modelBuilder.Entity<Thread>().ToTable("Threads").HasMany(b => b.Posts).WithOne(p => p.Thread);
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
    }
}
