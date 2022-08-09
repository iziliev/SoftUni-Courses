using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.; Database=HospitalDatabase;User Id=sa;Password=Ilievi84;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });
        }
    }
}
