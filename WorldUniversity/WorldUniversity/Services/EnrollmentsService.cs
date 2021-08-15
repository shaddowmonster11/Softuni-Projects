using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task EnrollStudent(string studentId
          , int courseId)
        {
            var student =  _context.Users
                .FirstOrDefault(s => s.Id == studentId);
            var course = _context.Courses.Single(c => c.Id == courseId);
            var enrollments = new Enrollment
            {
                StudentId = student.Id,
                Course = course,
                Student = student,
                Grade = "Waiting For Exam",
            };

            var enrollmentInDataBase = _context.Enrollments.Where(
                s =>
                        s.StudentId == enrollments.StudentId &&
                        s.Course.Id == enrollments.Course.Id)
            .SingleOrDefault();

            if (enrollmentInDataBase == null)
            {
                await _context.Enrollments.AddAsync(enrollments);
                student.Enrollments.Add(enrollments);
                _context.Users.Update(student);
            }
            await _context.SaveChangesAsync();
        }

        public ICollection<AssignUserToCourseViewModel> GetAllUnAssignedCoursesToUser(string userId)
        {
            var courses = _context.Courses
                 .Include(c => c.Enrollments)
                 .Include(c => c.Department)
                 .Select(c => new AssignUserToCourseViewModel
                 {
                     Title = c.Title,
                     Id = c.Id,
                     StudentId = userId,
                     Credits = c.Credits,
                     IsAssignedToUser = false,
                     Enrollments = c.Enrollments,
                 })
                 .ToList();

            return courses;
        }

        public ICollection<AssignUserToCourseViewModel> GetAllUserCourses(string userId)
        {
            var courses = GetAllUnAssignedCoursesToUser(userId);
            foreach (var course in courses)
            {
                var enrollment = _context.Enrollments
                 .FirstOrDefault(x => x.StudentId == userId && x.Course.Id == course.Id);
                course.IsAssignedToUser = course.Enrollments.Contains(enrollment);
            }
            return courses;
        }
    }
}
