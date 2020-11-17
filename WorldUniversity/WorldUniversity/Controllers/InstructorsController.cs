using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;
using WorldUniversity.Services;

namespace WorldUniversity.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstructorService instructorService;
        private readonly ICoursesService coursesService;
        //hello
        public InstructorsController(ApplicationDbContext context
            ,IInstructorService instructorService
            ,ICoursesService coursesService)
        {
            _context = context;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Enrollments)
                            .ThenInclude(i => i.Student)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;
                Instructor instructor = viewModel.Instructors.Where(i => i.ID == id.Value).Single();
                viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;
                var selectedCourse = viewModel.Courses.Where(x => x.CourseId == courseId).Single();

                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();

                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                viewModel.Enrollments = selectedCourse.Enrollments;
            }

            return View(viewModel);
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var instructor = instructorService.GetInstructorsDetails(id);
            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            var courses = coursesService.GetAll();
            var instructor = new GetInstructorsDetailsViewModel
            {
                CourseAssignments = courses,       
            };
            return View(instructor);
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GetInstructorsDetailsViewModel instructor)
        {
                                                                              
            if (ModelState.IsValid)
            {
                await this.instructorService.Create(instructor);
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void PopulateAssignedCourseData(GetInstructorsDetailsViewModel instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseId));
            var viewModel = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseId = course.CourseId,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseId)
                });
            }
            ViewData["Courses"] = viewModel;
        }
        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var courses = coursesService.GetAll();
            var listOfCourses = new List<int>();
            var instructor = instructorService.GetInstructorsDetails(id);
            foreach (var assingment in instructor.CourseAssignments)
            {
                listOfCourses.Add(assingment.CourseId);
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
            return RedirectToAction("Details","Instructors",new {id=instructor.Id});
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Instructor instructor = await _context.Instructors//?????????????
                        .Include(i => i.CourseAssignments)
                        .SingleAsync(i => i.ID == id);

            var departments = await _context.Departments
                    .Where(d => d.InstructorId == id)
                    .ToListAsync();

            departments.ForEach(d => d.InstructorId = null);

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }
    }
}