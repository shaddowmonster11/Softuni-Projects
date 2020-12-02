﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Repositories;
using WorldUniversity.Services;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.Controllers
{
    public class StudentsController:Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentsService studentService;

        public StudentsController(ApplicationDbContext context,IStudentsService studentService)
        {
            _context = context;
            this.studentService = studentService;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "dateDesc" : "date";
            DbInitializer dbInitializer = new DbInitializer();
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var studentViewModel = this.studentService.GetStudentAllData();

            if (!String.IsNullOrEmpty(searchString))
            {
                studentViewModel = studentViewModel.Where(s =>
                                        s.FirstName.Contains(searchString) ||
                                        s.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nameDesc":
                    studentViewModel = studentViewModel.OrderByDescending(s => s.FirstName);
                    break;
                case "date":
                    studentViewModel = studentViewModel.OrderBy(s => s.EnrollmentDate);
                    break;
                case "dateDesc":
                    studentViewModel = studentViewModel.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentViewModel = studentViewModel.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<StudentViewModel>.CreateAsync(studentViewModel.AsNoTracking(), pageNumber ?? 1, pageSize));
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
                ,studentViewModel.LastName,studentViewModel.EnrollmentDate,studentViewModel.Id);
            return RedirectToAction("Details", new { id = studentViewModel.Id });
        }

        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            var student= this.studentService.GetStudentDetails(id);

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
