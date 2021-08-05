using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models.ExamModels;
using WorldUniversity.ViewModels.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Services.Exams
{
    public class ExamsService : IExamsService
    {
        private readonly ApplicationDbContext _context;

        public ExamsService(ApplicationDbContext context)
        {
            _context = context;
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
                Id = input.Id,
                Title = input.Title,
                Date = input.Date,
                IsArchived = false,
            };
            await _context.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public bool ExamExists(string title, DateTime date)
        {
            return _context.Exams.Any(e => e.Title == title || e.Date == date);
        }

        public ICollection<ExamViewModel> GetAllExams()
        {
            var exam = _context.Exams
                .Where(x=>x.IsArchived==false)
                .Select(x => new ExamViewModel
                {
                    Id = x.Id,
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
    }
}
