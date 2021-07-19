﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Exams
{
    public class CreateQuestionInputModel
    {

        [Required(ErrorMessage = "Question is required")]
        public string Question { get; set; }

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
