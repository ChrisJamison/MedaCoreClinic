using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Add a DbSet for the Patient entity
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Service> Services { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}