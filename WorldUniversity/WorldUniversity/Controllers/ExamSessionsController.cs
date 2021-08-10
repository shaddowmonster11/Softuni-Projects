using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Controllers
{
    public class ExamSessionsController : Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;
        private readonly ICoursesService coursesService;

        public ExamSessionsController(IExamsService examsService
            , IQuestionsService questionsService
            , ICoursesService coursesService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
            this.coursesService = coursesService;
        }
        public IActionResult Index()
        {
            var courses = coursesService.GetAllUnAssignedCoursesToUser();
            return View(courses);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int courseId)
        {
          //  var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return RedirectToAction(nameof(Index));
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
