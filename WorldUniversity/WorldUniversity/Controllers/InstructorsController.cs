using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Services;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Instructors;

namespace WorldUniversity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstructorsService instructorService;
        private readonly ICoursesService coursesService;
        public InstructorsController(ApplicationDbContext context
            , IInstructorsService instructorService
            , ICoursesService coursesService)
        {
            _context = context;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
        }
        public IActionResult Index(int? id, int? courseId)
        {
            var viewModel = instructorService.GetInstructorAllData();
            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                var instructor = viewModel.Instructors.Where(i => i.ID == id).Single();
                viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseId != null)
            {
                ViewData["Id"] = courseId.Value;
                viewModel.Enrollments = viewModel.Courses.Where(x => x.Id == courseId).Single().Enrollments;
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var instructor = instructorService.GetInstructorsDetails(id);
            return View(instructor);
        }

        public IActionResult Create()
        {
            var courses = coursesService.GetAll();
            var instructor = new GetInstructorsDetailsViewModel
            {
                CourseAssignments = courses,
            };
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GetInstructorsDetailsViewModel instructor)
        {
            if (ModelState.IsValid)
            {
                await this.instructorService.Create(instructor);
                return RedirectToAction(nameof(Index));
            }
            var allCourses = coursesService.GetAllCourses();
            var viewModel = instructorService.PopulateAssignedCourseData(instructor,allCourses);
            ViewData["Courses"] = viewModel;
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            var courses = coursesService.GetAll();
            var listOfCourses = new List<int>();
            var instructor = instructorService.GetInstructorsDetails(id);
            foreach (var assingment in instructor.CourseAssignments)
            {
                listOfCourses.Add(assingment.Id);
            }
            instructor.SelectedCoursesId = listOfCourses.ToArray();
            instructor.CourseAssignments = courses;
            return View(instructor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetInstructorsDetailsViewModel instructor)
        {
            await instructorService.UpdateInstructor(
                instructor.FirstName,
                instructor.LastName,
                instructor.HireDate,
                instructor.OfficeAssignment,
                instructor.SelectedCoursesId,
                instructor.Id);
            return RedirectToAction("Index", "Instructors", new { id = instructor.Id });
        }

        public IActionResult Delete(int id)
        {
            var instructor = instructorService.GetInstructorsDetails(id);
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await instructorService.DeleteInstructor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}