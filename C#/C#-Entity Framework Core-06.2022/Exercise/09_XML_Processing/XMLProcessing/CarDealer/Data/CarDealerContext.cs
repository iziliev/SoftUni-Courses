using CarDealer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<PartCar> PartCars { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>()
                .HasKey(pc => new { pc.PartId, pc.CarId });
        }
    }
}
