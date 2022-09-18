using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Reflection;
using WorldUniversity.Models;
using WorldUniversity.Models.Entities;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
                   typeof(ApplicationDbContext).GetMethod(
                       nameof(SetIsDeletedQueryFilter),
                       BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<ExamAssignment> ExamAssignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignments");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignments");
            modelBuilder.Entity<ExamAssignment>().ToTable("ExamAssignments");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<ContactForm>().ToTable("ContractForms");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<CourseAssignment>()
                  .HasKey(c => new { c.CourseId, c.InstructorId });
            modelBuilder
                  .Entity<ExamAssignment>()
                 .HasMany(p => p.Students)
                 .WithMany(p => p.ExamAssignments);

            base.OnModelCreating(modelBuilder);
            EntityIndexesConfiguration.Configure(modelBuilder);
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { modelBuilder });
            }
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
           where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

    }
}
