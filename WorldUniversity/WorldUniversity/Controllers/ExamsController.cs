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
            return View();
        }
        public IActionResult CreateQuestion()
        {
            return View();
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
                ViewBag.ErrorMessage = $"Course with Title {exam.Title} already exists";
                return View("Error");

            }
            if (ModelState.IsValid)
            {
                await examsService.CreateExam(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }
    }  

}
