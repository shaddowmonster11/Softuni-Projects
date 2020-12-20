using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Services;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Enrollements;

namespace WorldUniversity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;

        public CoursesController(ApplicationDbContext context, ICoursesService coursesService)
        {
            _context = context;
            this.coursesService = coursesService;
        }
        public IActionResult Index()
        {
            var courses = coursesService.GetAllCourses();
            return View(courses);
        }
        [Authorize]
        public IActionResult Enrollment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Enrollment(CreateEnrollemntViewModel enrollment)
        {
            await coursesService.EnrollStudent(enrollment.FirstName, enrollment.LastName, enrollment.CourseTitle, enrollment.StudentGrade);
            return View();
        }
        public IActionResult Details(int id)
        {
            var course = coursesService.GetCoursesDetails(id);
            return View(course);
        }

        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseInputModel course)
        {
            if (ModelState.IsValid)
            {
                await coursesService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", course.DepartmentId);
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = coursesService.GetCoursesDetails(id);
            if (course == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(course.DepartmentId);
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
                    if (!coursesService.CourseExists(course.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", course.DepartmentId);
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

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = coursesService.PopulateDepartment(selectedDepartment);
            ViewBag.DepartmentId = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }
    }
}