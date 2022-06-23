using Microsoft.EntityFrameworkCore;
using CourseRegistration.Models;

namespace CourseRegistration.Data
{
    public class CourseRegistrationContext : DbContext
    {
        public CourseRegistrationContext(DbContextOptions<CourseRegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<RegistrationSheet>? RegistrationSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<RegistrationSheet>()
                .HasIndex(c => new { c.CourseId, c.StudentId })
                .IsUnique();
        }
    }
}
