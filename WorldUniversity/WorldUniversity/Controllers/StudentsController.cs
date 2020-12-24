using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldUniversity.Repositories;
using WorldUniversity.Services;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.Controllers
{
      [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentService;

        public StudentsController(IStudentsService studentService)
        {
            this.studentService = studentService;
        }

        public async Task<IActionResult> Index(
            int? pageNumber)
        {
            var studentViewModel = this.studentService.GetStudentAllData();          
            return View(await PaginatedList<StudentViewModel>
                .CreateAsync(studentViewModel.AsNoTracking(), pageNumber ?? 1));
        }

        public IActionResult Details(int id)
        {
            var studentViewModel = this.studentService.GetStudentDetails(id);
            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentInputViewModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await this.studentService.Create(input);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again and if the problem persists restart your PC.");
            }
            return View(input);
        }

        public IActionResult Edit(int id)
        {
            var student = studentService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(StudentViewModel studentViewModel)
        {
            await this.studentService.UpdateStudent(studentViewModel.FirstName
                , studentViewModel.LastName, studentViewModel.EnrollmentDate, studentViewModel.Id);
            return RedirectToAction("Details", new { id = studentViewModel.Id });
        }

        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            var student = this.studentService.GetStudentDetails(id);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed! Try again " +
                    "and if the proble persists restart your PC!";
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = this.studentService.GetStudentDetails(id);

            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await this.studentService.DeleteStudent(id);
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
