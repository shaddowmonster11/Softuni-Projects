using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public class ExamAssignmentsService : IExamAssignmentsService
    {
        private readonly ApplicationDbContext _context;

        public ExamAssignmentsService(ApplicationDbContext context
            , ICoursesService coursesService)
        {
            _context = context;
        }

        public async Task AddExamAssigmentToStudent(string userId, int courseId)
        {
            var student = _context.Users
                  .Include(x => x.ExamAssignments)
                  .FirstOrDefault(s => s.Id == userId);

            var examAssignments = GetAllExamAssignmentsByCourseId(courseId);

            student.ExamAssignments = examAssignments;
            _context.Users.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Create(int examId, int courseId)
        {
            var course = _context.Courses
                        .Include(x => x.ExamAssignments)
                        .Where(x => x.Id == courseId)
                        .FirstOrDefault();
            var exam = _context.Exams.
                Where(x => x.Id == examId)
                .FirstOrDefault();
            var examAssignment = new ExamAssignment
            {
                Course = course,
                CourseId = course.Id,
                Exam = exam,
                ExamId = exam.Id,
            };
            var students = _context.Users
                .Include(x => x.ExamAssignments)
                .Include(x => x.Enrollments)
                .ToList();
            foreach (var student in students)
            {
                var enrollemnts = student.Enrollments.ToList();
                foreach (var enrollment in enrollemnts)
                {
                    if (enrollment.Course != null)
                    {
                        student.ExamAssignments.Add(examAssignment);
                    }
                }
            }
            course.ExamAssignments.Add(examAssignment);
            await _context.AddAsync(examAssignment);
            await _context.SaveChangesAsync();
        }
        public bool ExamAssignmentExist(int examId, int courseId)
        {
            return _context.ExamAssignments.Any(x => x.ExamId == examId && x.CourseId == courseId);
        }

        public ICollection<ExamAssignmentViewModel> GetAllExamAssignments()
        {
            var examAssignments = _context.ExamAssignments
                .Include(x => x.Students)
                .Select(x => new ExamAssignmentViewModel
                {
                    Id = x.Id,
                    Course = x.Course,
                    CourseId = x.CourseId,
                    Exam = x.Exam,
                    ExamId = x.ExamId,
                }).ToList();

            return examAssignments;
        }

        public ICollection<ExamAssignment> GetAllExamAssignmentsByCourseId(int courseId)
        {
            var examAssignments = _context.ExamAssignments
                .Include(x => x.Students)
                .Where(x => x.CourseId == courseId)
                 .Select(x => new ExamAssignment
                 {
                     Id = x.Id,
                     Course = x.Course,
                     CourseId = x.CourseId,
                     Exam = x.Exam,
                     ExamId = x.ExamId,

                 }).ToList();
            return examAssignments;
        }

        public ExamAssignmentViewModel GetExamAssignmentByExamId(int id)
        {
            var examAssignment = _context.ExamAssignments
                .Where(x => x.Id == id)
               .Select(x => new ExamAssignmentViewModel
               {
                   Id = x.Id,
                   Course = x.Course,
                   CourseId = x.CourseId,
                   Exam = x.Exam,
                   ExamId = x.ExamId
               }).FirstOrDefault();

            return examAssignment;
        }
    }
}
