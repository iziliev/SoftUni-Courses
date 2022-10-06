using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Core.Data.Models;
using WebShopApp.Core.Data.Models.Account;

namespace WebShopApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasKey(p => new { p.Id });

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
    }
}