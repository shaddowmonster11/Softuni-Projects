using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Web.ViewModels.Departments;

namespace WorldUniversity.Web.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsService departmentsService;
        private readonly IInstructorsService instructorService;

        public DepartmentsController(IDepartmentsService departmentsService
            , IInstructorsService instructorService)
        {
            this.departmentsService = departmentsService;
            this.instructorService = instructorService;
        }
        public IActionResult Index()
        {
            return View(departmentsService.GetAdmin());
        }
        public IActionResult Details(int id)
        {
            var department = departmentsService.GetDepartmentDetails(id);
            return View(department);
        }
        public IActionResult Create()
        {
            var instructors = instructorService.GetAllInstructors();

            var department = new DepartmentInputModel
            {
                Instructors = instructors,
            };

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentInputModel department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            if (departmentsService.DepartmentExists(department.Name))
            {
                ViewBag.ErrorTitle = "Dublicated Name";
                ViewBag.ErrorMessage = $"Department with name {department.Name} already exists";
                return View("Error");
            }
            await departmentsService.Create(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var department = departmentsService.GetDepartmentDetails(id);
            var instructors = instructorService.GetAllInstructors();
            department.Instructors = instructors;
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentViewModel department)
        {
            try
            {
                await departmentsService.UpdateDepartment(department.DepartmentId
                    , department.Name, department.Budget
                    , department.StartDate, (int)department.InstructorId);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var clientValues = (DepartmentViewModel)exceptionEntry.Entity;
                var databaseEntry = exceptionEntry.GetDatabaseValues();

                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty,
                        "Unable to save changes, department was deleted by another user!");
                }
                else
                {
                    var databaseValues = (DepartmentViewModel)databaseEntry.ToObject();

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
                        var databaseInstructor = instructorService.GetInstructorsDetails(databaseValues.InstructorId);
                        ModelState.AddModelError("InstructorId", $"Current value: {databaseInstructor?.FullName}");
                    }

                    ModelState.AddModelError(String.Empty, "The record you attempted to edit was modified by another user."
                                                            + " The edit operation was cancelled and current values in the Database"
                                                            + " have been displayed.");
                }
                return View(department);
            }
        }
        public IActionResult Delete(int id, bool? concurrencyError)
        {
            var department = departmentsService.GetDepartmentDetails(id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var department = departmentsService.GetDepartmentDetails(id);
            try
            {
                await departmentsService.DeleteDepartment(id);
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = department.DepartmentId });
            }

        }
    }
}