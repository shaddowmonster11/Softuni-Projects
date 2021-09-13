using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Questions
{
    public class CreateQuestionInputModel
    {
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
    }
}
