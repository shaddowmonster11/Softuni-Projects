using System;
using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.ViewModels.Questions
{
    public class QuestionViewModel
    {
        public int QuestionID { get; set; }
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Question is required")]
        public string QuestionContent { get; set; }

        [Required(ErrorMessage = "Correct Answer is required")]
        public string CorrectAns { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        public string AlternateAnsOne { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        public string AlternateAnsTwo { get; set; }

        [Required(ErrorMessage = "Alternate Answer is required")]
        public string AlternateAnsThree { get; set; }
    }
}
