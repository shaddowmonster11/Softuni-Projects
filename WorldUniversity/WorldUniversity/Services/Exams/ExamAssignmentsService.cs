using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public class ExamAssignmentsService : IExamAssignmentsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;

        public ExamAssignmentsService(ApplicationDbContext context
            , ICoursesService coursesService)
        {
            _context = context;
            this.coursesService = coursesService;
        }
        public Task AssignExam(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            
            //  user.ExamAssignments.Add()
            throw new NotImplementedException();
        }

        public bool ExamAssignmentExist(int examId, int courseId)
        {
            return _context.ExamAssignments.Any(x => x.ExamId == examId && x.CourseId == courseId);
        }

        public ICollection<ExamAssignmentViewModel> GetAllExamAssignments()
        {
            var examAssignments = _context.ExamAssignments
                .Select(x => new ExamAssignmentViewModel
                {
                    Course = x.Course,
                    CourseId = x.CourseId,
                    Exam = x.Exam,
                    ExamId = x.ExamId
                }).ToList();

            return examAssignments;
        }

        public ExamAssignmentViewModel GetExamAssignmentByExamId(int examId)
        {
            var examAssignment = _context.ExamAssignments
                .Where(x => x.ExamId == examId)
               .Select(x => new ExamAssignmentViewModel
               {
                   Course = x.Course,
                   CourseId = x.CourseId,
                   Exam = x.Exam,
                   ExamId = x.ExamId
               }).FirstOrDefault();

            return examAssignment;
        }
    }
}
