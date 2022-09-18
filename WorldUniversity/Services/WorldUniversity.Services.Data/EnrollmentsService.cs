using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Data.Models;
using WorldUniversity.Services.Exams;
using WorldUniversity.Web.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IExamAssignmentsService examAssignmentsService;

        public EnrollmentsService(ApplicationDbContext context
            ,IExamAssignmentsService examAssignmentsService)
        {
            _context = context;
            this.examAssignmentsService = examAssignmentsService;
        }
        public async Task EnrollStudent(string studentId
          , int courseId)
        {
            var student = _context.Users
                .Include(x => x.ExamAssignments)
                .FirstOrDefault(s => s.Id == studentId);
            var course = _context.Courses.Single(c => c.Id == courseId);
            var enrollments = new Enrollment
            {
                StudentId = student.Id,
                Course = course,
                Student = student,
                Grade = "Waiting For Exam",
            };
            var examAssignments = examAssignmentsService.GetAllExamAssignmentsByCourseId(courseId);

            var enrollmentInDataBase = _context.Enrollments.Where(
                s =>
                        s.StudentId == enrollments.StudentId &&
                        s.Course.Id == enrollments.Course.Id)
            .SingleOrDefault();

            if (enrollmentInDataBase == null)
            {
                await _context.Enrollments.AddAsync(enrollments);
                student.Enrollments.Add(enrollments);
                foreach (var exam in examAssignments)
                {
                   student.ExamAssignments.Add(exam);                   
                }
                _context.Update(student);
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
