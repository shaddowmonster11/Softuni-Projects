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
        public InstructorsController(ApplicationDbContext context
            ,IInstructorService instructorService
            ,ICoursesService coursesService)
        {
            _context = context;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
        }
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var viewModel = instructorService.GetInstructorAllData();
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
        public IActionResult Edit(int id)
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
            return RedirectToAction("Index","Instructors",new {id=instructor.Id});
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