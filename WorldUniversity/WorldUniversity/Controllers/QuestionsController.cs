using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Controllers
{
    public class QuestionsController:Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;

        public QuestionsController(IExamsService examsService
            , IQuestionsService questionsService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
        }
        public IActionResult CreateQuestion(int examId)
        {
            var question = new CreateQuestionInputModel
            {
                ExamId = examId,
            };
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(CreateQuestionInputModel question)
        {
            if (questionsService.QuestionExist(question.QuestionContent))
            {
                ViewBag.ErrorTitle = "Dublicated Question";
                ViewBag.ErrorMessage = $"Question with Title {question.QuestionContent} already exists";
                return View("Error");

            }
            if (ModelState.IsValid)
            {
                await questionsService.CreateQuestion(question);
                return RedirectToAction("Index","Exams");
            }
            return View(question);
        }
    }
}
