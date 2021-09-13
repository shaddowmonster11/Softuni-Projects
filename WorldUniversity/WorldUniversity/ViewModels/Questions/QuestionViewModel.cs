using System;
using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.ViewModels.Questions
{
    public class QuestionViewModel
    {
        public int QuestionID { get; set; }
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Question is required")]
        [Display(Name = "Question Content")]
        public string QuestionContent { get; set; }

        [Required(ErrorMessage = "Correct Answer is required")]
        [Display(Name = "Correct Answer")]
        public string CorrectAns { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        [Display(Name = "First Alternative Answer")]
        public string AlternateAnsOne { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        [Display(Name = "Second Alternative Answer")]
        public string AlternateAnsTwo { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        [Display(Name = "Third Alternative Answer")]
        public string AlternateAnsThree { get; set; }
        public bool IsArchived { get; set; }
    }
}
