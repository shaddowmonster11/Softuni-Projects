using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldUniversity.Data.Common.Repositories;
using WorldUniversity.Services;
using WorldUniversity.Web.ViewModels.Students;

namespace WorldUniversity.Web.Controllers
{
    [Authorize(Roles = "Admin,Moderator,User")]
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

        public IActionResult Details(string id)
        {
            var studentViewModel = this.studentService.GetStudentDetails(id);
            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        public IActionResult Delete(string id, bool? saveChangesError = false)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
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
