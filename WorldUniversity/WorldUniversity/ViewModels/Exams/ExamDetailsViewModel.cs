using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Exams
{
    public class ExamDetailsViewModel
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        [DisplayName("Date and Time")]
        public DateTime Date { get; set; }
    }
}