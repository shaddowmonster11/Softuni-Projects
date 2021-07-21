using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignments");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignments");
            modelBuilder.Entity<ContactForm>().ToTable("ContractForms");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<CourseAssignment>()
                  .HasKey(c => new { c.Id, c.InstructorId });

            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
