using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;

        public CoursesController(ApplicationDbContext context, ICoursesService coursesService)
        {
            _context = context;
            this.coursesService = coursesService;
        }
        public async Task<IActionResult> Index()
        {
            var courses = coursesService.GetAllCourses();
            return View(courses);
        }

        public async Task<IActionResult> Details(int id)
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
        public async Task<IActionResult> Create(CourseViewModel course)
        {
            //Have to Add Validation For Id where CourseId=context.CourseId
            if (ModelState.IsValid)
            {
                await coursesService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", course.DepartmentId);
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
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
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await coursesService.UpdateCourse(course.CourseId, course.Title
                        , course.Credits, course.DepartmentId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!coursesService.CourseExists(course.CourseId))
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

        public async Task<IActionResult> Delete(int id)
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