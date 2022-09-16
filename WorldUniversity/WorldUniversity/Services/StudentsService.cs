using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly ApplicationDbContext _context;

        public StudentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteStudent(string id)
        {
            var student = _context.Users
             .FirstOrDefault(m => m.Id == id);
            student.IsDeleted = true;
            student.UserName = null;
            student.NormalizedUserName = null;
            student.DeletedOn = DateTime.UtcNow;
            _context.Update(student);
            var studentEnrollemnts = _context.Enrollments.Where(s => s.StudentId == id).ToList();
            var roles = student.Roles.ToList();
            foreach (var role in roles)
            {
                roles.Remove(role);
                _context.Update(role);
            }

            if (studentEnrollemnts.Count != 0)
            {
                foreach (var enrollement in studentEnrollemnts)
                {
                    enrollement.IsDeleted = true;
                    enrollement.DeletedOn = DateTime.UtcNow;
                    _context.Update(enrollement);
                }

            }

            await _context.SaveChangesAsync();
        }
        public IQueryable<StudentViewModel> GetStudentAllData()
        {
            var student = _context.Users
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .Select(x => new StudentViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Enrollments = x.Enrollments,
            }
            );

            return student;
        }

        public StudentViewModel GetStudentDetails(string id)
        {
            var student = _context.Users
                .Where(x => x.Id == id)
               .Include(s => s.Enrollments)
               .ThenInclude(e => e.Course)
               .Select(x => new StudentViewModel
               {
                   Id = x.Id,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Email = x.Email,
                   Enrollments = x.Enrollments,
               }
               )
               .FirstOrDefault();
            return student;
        }
        public bool StudentExists(string firstName, string lastName)
        {
            return _context.Users.Any(e => e.FirstName == firstName && e.LastName == lastName);
        }
    }
}
