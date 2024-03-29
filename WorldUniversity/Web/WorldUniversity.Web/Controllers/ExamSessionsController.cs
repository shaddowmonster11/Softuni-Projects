﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Services.Exams;
using WorldUniversity.Web.ViewModels.Courses;
using WorldUniversity.Web.ViewModels.Exams;
using WorldUniversity.Web.ViewModels.Questions;

namespace WorldUniversity.Web.Controllers
{
    public class ExamSessionsController : Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;
        private readonly IEnrollmentsService enrollmentsService;

        public ExamSessionsController(IExamsService examsService
            , IQuestionsService questionsService
            , IEnrollmentsService enrollmentsService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
            this.enrollmentsService = enrollmentsService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = enrollmentsService.GetAllUserCourses(userId);
           // return View("Test");
            return View(courses);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                await enrollmentsService.EnrollStudent(userId, courseId);            
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult ListExams()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exams = examsService.GetAllUserExams(userId);
           // return PartialView("Test");
            return View(exams);

        }
        public IActionResult Test1()
        {

            return View();

        }
        public IActionResult TakeExam()
        {
            return View();
        }
  
    }
}
