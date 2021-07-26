﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Services.Exams;
using WorldUniversity.ViewModels.Exams;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.Controllers
{

    public class ExamsController:Controller
    {
        private readonly IExamsService examsService;
        private readonly IQuestionsService questionsService;

        public ExamsController(IExamsService examsService
            ,IQuestionsService questionsService)
        {
            this.examsService = examsService;
            this.questionsService = questionsService;
        }
        public IActionResult Index()
        {
            var exams = examsService.GetAllExams();
            return View(exams);
        }       
        public IActionResult CreateExam()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam(CreateExamInputModel exam)
        {
            if (examsService.ExamExists(exam.Title,exam.Date))
            {
                ViewBag.ErrorTitle = "Dublicated Name";
                ViewBag.ErrorMessage = $"Exam with Title {exam.Title} already exists";
                return View("Error");

            }
            if (ModelState.IsValid)
            {
                await examsService.CreateExam(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }
        public IActionResult ExamDetails(int id)
        {
            var exam = examsService.GetExamAllDetails(id);
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveExam(int id)
        {
            await examsService.ArchieveExam(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditExam(int id)
        {
            var exam = examsService.GetExamDetails(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExam(int id, ExamDetailsViewModel exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await examsService.UpdateExam(exam);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!examsService.ExamExists(exam.Title,exam.Date))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ExamDetails", "Exams", new { id = exam.ExamId });
            }
            return View(exam);
        }

    }

}
