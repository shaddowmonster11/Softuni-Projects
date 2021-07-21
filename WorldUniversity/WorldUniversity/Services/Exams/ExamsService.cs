using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models.ExamModels;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public class ExamsService : IExamsService
    {
        private readonly ApplicationDbContext _context;

        public ExamsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateExam(CreateExamInputModel input)
        {
            var exam = new Exam
            {
                Title = input.Title,
                Date = input.Date,
                IsArchived = false,
            };
            await _context.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int id)
        {
            var exam = _context.Exams.First(ex => ex.Id == id);
            if(exam.Questions.Count<0)
            {
                var deleteExam = _context.Exams
                    .AsNoTracking()
                    .FirstOrDefault(ex => ex.Id == id);
                _context.Exams.Remove(deleteExam);
                await _context.SaveChangesAsync();
            }          
        }

        public bool ExamExists(string title, string date)
        {
            return _context.Exams.Any(e => e.Title == title && e.Date == date);
        }

        public IQueryable<ExamViewModel> GetAllExams()
        {
            /*var questions = _context.Exams.Select(x => new QuestionViewModel
            {
            });
            var exam = _context.Exams
            .Select(x => new ExamViewModel
            {
               Title=x.Title,
               Date=x.Date,
               IsArchived=x.IsArchived,
               Questions=x.Questions,

            }
            );
*/
            //          return exam;
            throw new NotImplementedException();
        }

        public ExamViewModel GetExamDetails(int id)
        {
            throw new NotImplementedException();//needs questions service before implementing
        }

        public Task UpdateExam(string title, string date, int ExamId)
        {
            throw new NotImplementedException();//waiting for the Question views and storages
        }
    }
}
