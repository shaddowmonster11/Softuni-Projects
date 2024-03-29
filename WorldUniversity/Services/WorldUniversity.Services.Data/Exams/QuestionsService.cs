﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Data.Models.ExamModels;
using WorldUniversity.Web.ViewModels.Questions;

namespace WorldUniversity.Services.Exams
{
    public class QuestionsService : IQuestionsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IExamsService examsService;

        public QuestionsService(ApplicationDbContext context
            , IExamsService examsService)
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
                ExamId = input.ExamId,
                IsArchived = false,
            };
            await _context.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int id)
        {
            var deleteQuestion = _context.Questions
                .FirstOrDefault(ex => ex.Id == id && ex.IsArchived == false);
            _context.Questions.Remove(deleteQuestion);
            await _context.SaveChangesAsync();
        }
        public ICollection<QuestionViewModel> GetAllQuestions()
        {
            var questions = _context.Questions
                 .Select(x => new QuestionViewModel
                 {
                     QuestionID = x.Id,
                     QuestionContent = x.QuestionContent,
                     AlternateAnsOne = x.AlternateAnsOne,
                     AlternateAnsTwo = x.AlternateAnsTwo,
                     AlternateAnsThree = x.AlternateAnsThree,
                     CorrectAns = x.Answer,
                     ExamId = x.ExamId,
                 }).ToList();
            return questions;
        }

        public QuestionViewModel GetQuestionById(int questionId)
        {
            var question = _context.Questions
                .Where(x => x.Id == questionId)
                 .Select(x => new QuestionViewModel
                 {
                     QuestionID = x.Id,
                     QuestionContent = x.QuestionContent,
                     AlternateAnsOne = x.AlternateAnsOne,
                     AlternateAnsTwo = x.AlternateAnsTwo,
                     AlternateAnsThree = x.AlternateAnsThree,
                     CorrectAns = x.Answer,
                     ExamId = x.ExamId,
                 }).FirstOrDefault();
            return question;
        }

        public bool QuestionExist(string questionContent)
        {
            return _context.Questions.Any(e => e.QuestionContent == questionContent && e.IsArchived == false);
        }
    }
}
