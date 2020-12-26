using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Enrollements;

namespace WorldUniversity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ICoursesService coursesService;
        private readonly IDepartmentsService departmentsService;
        private readonly IStudentsService studentsService;

        public CoursesController(ICoursesService coursesService
            , IDepartmentsService departmentsService, IStudentsService studentsService)
        {
            this.coursesService = coursesService;
            this.departmentsService = departmentsService;
            this.studentsService = studentsService;
        }
        public IActionResult Index()
        {
            var courses = coursesService.GetAllCourses();
            return View(courses);
        }
        [Authorize]
        public IActionResult Enrollment()
        {
            var students = studentsService.GetStudentAllData().ToList();
            var courses = coursesService.GetAllCourses();
            var student = new CreateEnrollemntViewModel
            {
                Students = students,
                Courses = courses,
            };
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Enrollment(CreateEnrollemntViewModel enrollment)
        {
            if (ModelState.IsValid)
            {
                await coursesService.EnrollStudent(enrollment.StudentId
                 , enrollment.CourseId
                 , enrollment.StudentGrade);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            var course = coursesService.GetCoursesDetails(id);
            return View(course);
        }

        public IActionResult Create()
        {
            var departments = departmentsService.GetAdmin();

            var department = new CourseInputModel
            {
                Departments = departments,
            };
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseInputModel course)
        {
            if (coursesService.CourseExists(course.Title))
            {
                ViewBag.ErrorTitle = "Dublicated Name";
                ViewBag.ErrorMessage = $"Course with Title {course.Title} already exists";
                return View("Error");

            }
            if (ModelState.IsValid)
            {
                await coursesService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = coursesService.GetCoursesDetails(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GetCoursesDetailsViewModel course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await coursesService.UpdateCourse(course.Id, course.Title
                        , course.Credits, course.DepartmentId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!coursesService.CourseExists(course.Title))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = coursesService.GetCoursesDetails(id);
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await coursesService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}