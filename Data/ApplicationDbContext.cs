using HospitalManagementSystem.Helpers.Enums;
using HospitalManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>().HasKey(e => new {e.PatientName, e.DoctorId});
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {Id=1,Name="Buğra",Branch=Branch.Cardiology,Patients=null },
                new Doctor {Id = 2, Name = "Emirhan", Branch = Branch.Orthopedics, Patients = null },
                new Doctor {Id = 3, Name = "Safiye", Branch = Branch.Pediatrics, Patients = null },
                new Doctor { Id = 4, Name = "Muhammet", Branch = Branch.Dermatology, Patients = null },
                new Doctor { Id = 5, Name = "Can", Branch = Branch.Neurology, Patients = null }
                );
        }
    }
}
