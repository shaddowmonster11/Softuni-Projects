using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
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
            var deletedStudent = _context.Users
             .FirstOrDefault(m => m.Id == id);
          /*  if (_context.Enrollments.Any(x => x.StudentId == id))
            {
                var enrollmentToRemove = _context.Enrollments.Where(x => x.StudentId == id).ToList();
                foreach (var subject in enrollmentToRemove)
                {
                    _context.Enrollments.Remove(subject);
                }
            }*/
             _context.Users.Remove(deletedStudent);
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
