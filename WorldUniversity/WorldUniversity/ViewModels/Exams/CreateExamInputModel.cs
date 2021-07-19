using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Exams
{
    public class CreateExamInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
