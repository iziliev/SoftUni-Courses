using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<User>
    {
        private User GuestUser { get; set; }

        private Board OpenBoard { get; set; }

        private Board InProgressBoard { get; set; }

        private Board DoneBoard { get; set; }

        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();

            builder.Entity<User>()
                .HasData(GuestUser);

            SeedBoards();

            builder.Entity<Board>()
                .HasData(OpenBoard,InProgressBoard,DoneBoard);

            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Fundamentals exam",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL Management Studio",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = GuestUser.Id,
                    BoardId = DoneBoard.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddDays(-10),
                    OwnerId = GuestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals Exam",
                    Description = "Prepare by solving old Mid and Final exams",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = DoneBoard.Id
                });

            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest");
        }
    }
}