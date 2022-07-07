using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Bet366;User Id=sa;Password=Ilievi84;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e=>
            {
                e.HasKey(ps => new { ps.PlayerId, ps.GameId });
            });

            modelBuilder.Entity<Team>(e =>
            {
                e
                    .HasOne(c=>c.PrimaryKitColor)
                    .WithMany(t=>t.PrimaryKitTeams)
                    .HasForeignKey(pk=>pk.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
                e
                    .HasOne(c => c.SecondaryKitColor)
                    .WithMany(t => t.SecondaryKitTeams)
                    .HasForeignKey(sc => sc.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(e =>
            {
                e
                    .HasOne(c => c.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
                e
                    .HasOne(c => c.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
