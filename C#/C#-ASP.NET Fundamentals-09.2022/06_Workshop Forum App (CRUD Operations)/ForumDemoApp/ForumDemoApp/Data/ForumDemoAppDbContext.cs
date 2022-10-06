using ForumDemoApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumDemoApp.Data
{
    public class ForumDemoAppDbContext : DbContext
    {
        public ForumDemoAppDbContext(DbContextOptions<ForumDemoAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(e => new { e.Id });

            modelBuilder.Entity<Post>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
