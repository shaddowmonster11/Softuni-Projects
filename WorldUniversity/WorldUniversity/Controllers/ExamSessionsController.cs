using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Courses;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                await coursesService.EnrollStudent(userId, courseId);
               /* var selectedCourse = coursesService.GetAllUnAssignedCoursesToUser()
                     .Where(x => x.Id == courseId)
                     .Select(x => x.Enrollments
                     .Where(c => c.StudentId == userId && c.Id == courseId)
                     .FirstOrDefault())
                     .FirstOrDefault();
                coursesService.GetAllUnAssignedCoursesToUser()
                    .Where(x => x.Id == courseId)
                    .Select(x => new AssignUserToCourseViewModel
                    {
                        Id = x.Id,
                        Credits = x.Credits,
                        Title = x.Title,
                        IsAssignedToUser = x.Enrollments.Contains(selectedCourse),
                        Enrollments = x.Enrollments,
                        ExamAssignments = x.ExamAssignments,
                    });*/
                return RedirectToAction(nameof(Index));
            }
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
