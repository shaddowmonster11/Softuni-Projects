using Microsoft.EntityFrameworkCore;
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
    public class QuestionsService : IQuestionsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IExamsService examsService;

        public QuestionsService(ApplicationDbContext context, IExamsService examsService)
        {
            _context = context;
            this.examsService = examsService;
        }
        public async Task CreateQuestion(CreateQuestionInputModel input)
        {
            var question = new Question
            {
                QuestionContent = input.QuestionContent,
                AlternateAnsOne = input.AlternateAnsOne,
                AlternateAnsTwo = input.AlternateAnsTwo,
                AlternateAnsThree = input.AlternateAnsThree,
                Answer = input.CorrectAns,
                ExamId=input.ExamId,

            };
            await _context.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int id)
        {
                var deleteQuestion = _context.Questions
                    .AsNoTracking()
                    .FirstOrDefault(ex => ex.Id == id);
                _context.Questions.Remove(deleteQuestion);
                await _context.SaveChangesAsync();     
        }

        public ICollection<QuestionViewModel> GetAllQuestions()
        {
            var questions = _context.Questions
                 .Select(x=>new QuestionViewModel 
                 {
                     QuestionID=x.Id,
                     QuestionContent = x.QuestionContent,
                     AlternateAnsOne = x.AlternateAnsOne,
                     AlternateAnsTwo = x.AlternateAnsTwo,
                     AlternateAnsThree = x.AlternateAnsThree,
                     CorrectAns = x.Answer,
                     ExamId = x.ExamId,
                 }).ToList();
            return questions;
        }

        public bool QuestionExist(string questionContent)
        {
            return _context.Questions.Any(e => e.QuestionContent == questionContent);
        }
    }
}
