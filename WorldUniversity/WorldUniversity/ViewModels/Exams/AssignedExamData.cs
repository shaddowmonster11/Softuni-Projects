using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Exams
{
    public class AssignedExamData
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
