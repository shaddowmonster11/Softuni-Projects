using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.ViewModels.Exams
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Marks { get; set; }
        public string Title { get; set; }
        [Display(Name = "Exam Date")]
        public DateTime Date { get; set; }
        public bool IsArchived { get; set; }
        [Display(Name = "Number Of Questions")]
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
