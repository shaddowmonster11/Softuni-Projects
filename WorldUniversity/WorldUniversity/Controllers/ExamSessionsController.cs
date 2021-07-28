using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Controllers
{
    public class ExamSessionsController:Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;

        public ExamSessionsController(IExamsService examsService
            , IQuestionsService questionsService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
        }
        public IActionResult Index()
        {
            var exams = examsService.GetAllExams();
            return View(exams);
        }
    }
}
