using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Services.Exams;
using WorldUniversity.Web.ViewModels.Exams;
using WorldUniversity.Web.ViewModels.Questions;

namespace WorldUniversity.Web.Controllers
{

    public class ExamsController : Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;
        private readonly ICoursesService coursesService;

        public ExamsController(IExamsService examsService
            , IQuestionsService questionsService
            , ICoursesService coursesService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
            this.coursesService = coursesService;
        }
        public IActionResult Index()
        {
            var exams = examsService.GetAllExams();
            return View(exams);
        }
        public IActionResult CreateExam()
        {
            var courses = coursesService.GetAllCourses();
            var course = new CreateExamInputModel
            {
                Courses = courses,
            };
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam(CreateExamInputModel exam)
        {
            if (examsService.ExamExists(exam.Title, exam.Date) && !examsService.ExamIsArchieved(exam.Title))
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
            var allExams = examsService.GetAllExams();
            var viewModel = examsService.PopulateAssignedExamData(exam.CourseId, allExams);
            return View(exam);
        }
        public IActionResult ExamDetails(int id)
        {
            var exam = examsService.GetExamAllDetails(id);         
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveExam(int id)
        {
            await examsService.ArchieveExam(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditExam(int id)
        {
            var exam = examsService.GetExamDetails(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExam(int id, ExamDetailsViewModel exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await examsService.UpdateExam(exam);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!examsService.ExamExists(exam.Title, exam.Date))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ExamDetails", "Exams", new { id = exam.ExamId });
            }
            return View(exam);
        }

    }

}
