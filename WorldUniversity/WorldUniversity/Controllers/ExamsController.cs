using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Controllers
{

    public class ExamsController:Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;

        public ExamsController(IExamsService examsService
            ,IQuestionsService questionsService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
        }
        public IActionResult Index()
        {
            var exams = examsService.GetAllExams();
            return View(exams);
        }
        public IActionResult CreateQuestion(int examId)
        {
            var question = new CreateQuestionInputModel
            {
                ExamId=examId,
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
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }
        public IActionResult CreateExam()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam(CreateExamInputModel exam)
        {
            if (examsService.ExamExists(exam.Title,exam.Date))
            {
                ViewBag.ErrorTitle = "Dublicated Name";
                ViewBag.ErrorMessage = $"Exam with Title {exam.Title} already exists";
                return View("Error");

            }
            if (ModelState.IsValid)
            {
                await examsService.CreateExam(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }
        public IActionResult ExamDetails(int id)
        {
            var exam = examsService.GetExamDetails(id);
            return View(exam);
        }
        public IActionResult EditExam()
        {   
            return View();
        }
      
    }  

}
