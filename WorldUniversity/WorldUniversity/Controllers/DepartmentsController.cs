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
    public class DepartmentsController:Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentsService departmentsService;
        private readonly IInstructorService instructorService;

        public DepartmentsController(ApplicationDbContext context
            ,IDepartmentsService departmentsService
            ,IInstructorService instructorService)
        {
            _context = context;
            this.departmentsService = departmentsService;
            this.instructorService = instructorService;
        }

        public IActionResult Index()
        {          
            return View(departmentsService.GetAdmin());
        }

        // GET: Departments/Details/5
        public IActionResult Details(int id)
        {
            var department = departmentsService.GetDepartmentDetails(id);
            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            var instructors = instructorService.GetAllInstructors();

            var department = new DepartmentViewModel
            {
                Instructors = instructors,
            };

            return View(department);
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            await departmentsService.Create(department);
            return RedirectToAction(nameof(Index));
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(i => i.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorId);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentToUpdate = await _context.Departments
                    .Include(i => i.Administrator)
                    .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (departmentToUpdate == null)
            {
                Department deletedDepartment = new Department();
                await TryUpdateModelAsync(deletedDepartment);
                ModelState.AddModelError(string.Empty, "Unable to save changes. Department was deleted by another user!");
                ViewData["Instructor"] = new SelectList(_context.Instructors, "ID", "FullName", deletedDepartment.InstructorId);
                return View(deletedDepartment);
            }

            _context.Entry(departmentToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "",
                s => s.Name,
                s => s.StartDate,
                s => s.Budget,
                s => s.InstructorId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();

                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes, department was deleted by another user!");
                    }
                    else
                    {
                        var databaseValues = (Department)databaseEntry.ToObject();

                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }
                        if (databaseValues.Budget != clientValues.Budget)
                        {
                            ModelState.AddModelError("Budget", $"Current value: {databaseValues.Budget:c}");
                        }
                        if (databaseValues.StartDate != clientValues.StartDate)
                        {
                            ModelState.AddModelError("StartDate", $"Current value: {databaseValues.StartDate:d}");
                        }
                        if (databaseValues.InstructorId != clientValues.InstructorId)
                        {
                            Instructor databaseInstructor = await _context.Instructors
                                                            .FirstOrDefaultAsync(i => i.ID == databaseValues.InstructorId);

                            ModelState.AddModelError("InstructorId", $"Current value: {databaseInstructor?.FullName}");
                        }

                        ModelState.AddModelError(String.Empty, "The record you attempted to edit was modified by another user."
                                                                + " The edit operation was cancelled and current values in the Database"
                                                                + " have been displayed.");
                        departmentToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }

            ViewData["InstructorId"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorId);
            return View(departmentToUpdate);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }

            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                        + "was modified by another user after you got the original values. "
                        + "The delete operation was cancelled. "
                        + "You may try again!";

            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            try
            {
                if (await _context.Departments.AnyAsync(m => m.DepartmentId == department.DepartmentId))
                {
                    _context.Departments.Remove(department);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = department.DepartmentId });
            }
        }
    }
}