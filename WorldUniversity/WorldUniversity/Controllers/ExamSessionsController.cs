using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }
        public IActionResult ListExams()
        {
            var exams = examsService.GetAllExams();
            return View(exams);
        }
        public IActionResult TakeExam()
        { 
            return View();
        }
       /* [HttpPost, ActionName("TakeExam")]
        [ValidateAntiForgeryToken]
        public IActionResult TakeConfirmation(int id)
        {
            var student = 0;

            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
               // await this.studentService.DeleteStudent(id);
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(TakeExam), new { id = id, saveChangesError = true });
            }
        }*/
    }
}
