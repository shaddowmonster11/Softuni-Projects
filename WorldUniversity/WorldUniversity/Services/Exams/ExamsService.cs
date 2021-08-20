using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Models.ExamModels;
using WorldUniversity.ViewModels.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Services.Exams
{
    public class ExamsService : IExamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;
        private readonly IEnrollmentsService enrollmentsService;
        private readonly IExamAssignmentsService examAssignmentsService;

        public ExamsService(ApplicationDbContext context
            , ICoursesService coursesService
            , IEnrollmentsService enrollmentsService
            , IExamAssignmentsService examAssignmentsService)
        {
            _context = context;
            this.coursesService = coursesService;
            this.enrollmentsService = enrollmentsService;
            this.examAssignmentsService = examAssignmentsService;
        }

        public async Task ArchieveExam(int id)
        {
            var updateExam = _context.Exams
              .FirstOrDefault(s => s.Id == id);
            updateExam.IsArchived = true;

            _context.Update(updateExam);
            await _context.SaveChangesAsync();
        }

        public async Task CreateExam(CreateExamInputModel input)
        {
            var exam = new Exam
            {
                CourseId = input.CourseId,
                Title = input.Title,
                Date = input.Date,
                IsArchived = false,
            };

            await _context.AddAsync(exam);
            await _context.SaveChangesAsync();
            await examAssignmentsService.Create(exam.Id,exam.CourseId); 
        }
        public List<AssignedExamData> PopulateAssignedExamData(int courseId,
        ICollection<ExamViewModel> allExams)
        {
            var course = coursesService.GetAllCourses().FirstOrDefault(x => x.Id == courseId);
            var courseExams = new HashSet<int>(course.ExamAssignments.Select(c => c.CourseId));
            var viewModel = new List<AssignedExamData>();
            foreach (var exam in allExams)
            {
                viewModel.Add(new AssignedExamData
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Assigned = courseExams.Contains(exam.Id)
                });
            }
            return viewModel;
        }
        public bool ExamExists(string title, DateTime date)
        {
            return _context.Exams.Any(e => e.Title == title || e.Date == date);
        }

        public ICollection<ExamViewModel> GetAllExams()
        {
            var exam = _context.Exams
                .Where(x => x.IsArchived == false)
                .Select(x => new ExamViewModel
                {
                    Id = x.Id,
                    CourseId = x.CourseId,
                    Title = x.Title,
                    Date = x.Date,
                    IsArchived = x.IsArchived,
                    Questions = x.Questions.Select(x => new QuestionViewModel
                    {
                        ExamId = x.ExamId,
                        QuestionID = x.Id,
                        AlternateAnsOne = x.AlternateAnsOne,
                        AlternateAnsTwo = x.AlternateAnsTwo,
                        AlternateAnsThree = x.AlternateAnsThree,
                        CorrectAns = x.Answer,
                        QuestionContent = x.QuestionContent,
                    }).ToList(),
                }).ToList();
            return exam;
        }

        public ExamViewModel GetExamById(int Id)
        {
            var exam = _context.Exams
                .Where(ex => ex.Id == Id)
                .Select(x => new ExamViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    IsArchived = x.IsArchived,
                    Questions = x.Questions.Select(x => new QuestionViewModel
                    {
                        QuestionID = x.Id,
                        AlternateAnsOne = x.AlternateAnsOne,
                        AlternateAnsTwo = x.AlternateAnsTwo,
                        AlternateAnsThree = x.AlternateAnsThree,
                        CorrectAns = x.Answer,
                        QuestionContent = x.QuestionContent,
                    }).ToList(),
                    Marks = x.Marks,//????
                    Title = x.Title,
                }).FirstOrDefault();
            return exam;

        }

        public ExamViewModel GetExamAllDetails(int id)
        {
            var exam = _context.Exams
                 .Where(ex => ex.Id == id)
                 .Select(x => new ExamViewModel
                 {
                     Id = x.Id,
                     Date = x.Date,
                     IsArchived = x.IsArchived,
                     Questions = x.Questions.Select(x => new QuestionViewModel
                     {
                         ExamId = x.ExamId,
                         QuestionID = x.Id,
                         AlternateAnsOne = x.AlternateAnsOne,
                         AlternateAnsTwo = x.AlternateAnsTwo,
                         AlternateAnsThree = x.AlternateAnsThree,
                         CorrectAns = x.Answer,
                         QuestionContent = x.QuestionContent,
                     }).ToList(),
                     Marks = x.Marks,
                     Title = x.Title,
                 }).FirstOrDefault();
            return exam;
        }
        public async Task UpdateExam(ExamDetailsViewModel exam)
        {
            var updateExam = _context.Exams
              .FirstOrDefault(s => s.Id == exam.ExamId);
            updateExam.Id = exam.ExamId;
            updateExam.Title = exam.Title;
            updateExam.Date = exam.Date;

            _context.Update(updateExam);
            await _context.SaveChangesAsync();
        }

        public ExamDetailsViewModel GetExamDetails(int id)
        {
            var exam = _context.Exams
                .Where(ex => ex.Id == id)
                .Select(x => new ExamDetailsViewModel
                {
                    ExamId = x.Id,
                    Date = x.Date,
                    Title = x.Title,
                }).FirstOrDefault();
            return exam;
        }

        public bool ExamIsArchieved(string title)
        {
            var isExamArchieved = _context.Exams
                .Where(ex => ex.Title == title)
                .FirstOrDefault()
                .IsArchived;
            if (isExamArchieved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<ExamViewModel> GetAllUserExams(string userId)
        {          
            var user = _context.Users
                .Include(x => x.ExamAssignments)
                .Include(x=>x.Enrollments)
                .Where(x => x.Id == userId)
                .FirstOrDefault();
            var courses = new List<ExamViewModel>();
            foreach (var item in user.ExamAssignments)
            {
                var courseToAdd = GetExamAllDetails(item.ExamId);
                courses.Add(courseToAdd);
            }

            return courses;
        }
    }
}
