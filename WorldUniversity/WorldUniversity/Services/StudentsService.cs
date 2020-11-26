using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly ApplicationDbContext _context;

        public StudentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateStudentInputViewModel input)
        {
            var student = new Student
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EnrollmentDate = input.EnrollmentDate,
            };

            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var deletedStudent = _context.Students
             .AsNoTracking()
             .FirstOrDefault(m => m.Id == id);
             _context.Students.Remove(deletedStudent);
            await _context.SaveChangesAsync();
        }
        public IQueryable<StudentViewModel> GetStudentAllData()
        {
            var student = _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .Select(x => new StudentViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EnrollmentDate = x.EnrollmentDate,
                Enrollments = x.Enrollments,
            }
            );

            return student;
        }

        public StudentViewModel GetStudentDetails(int id)
        {
            var student = _context.Students
                .Where(x => x.Id == id)
               .Include(s => s.Enrollments)
               .ThenInclude(e => e.Course)
               .Select(x => new StudentViewModel
               {
                   Id = x.Id,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   EnrollmentDate = x.EnrollmentDate,
                   Enrollments = x.Enrollments,
               }
               )
               .FirstOrDefault();
            return student;
        }

        public async Task UpdateStudent(string firstName, string lastName, DateTime enrollmentDate, int id)
        {
            var updatedStudent = _context.Students
              .FirstOrDefault(s => s.Id == id);
            updatedStudent.FirstName = firstName;
            updatedStudent.LastName = lastName;
            updatedStudent.EnrollmentDate = enrollmentDate;
            await _context.SaveChangesAsync();
        }
        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
