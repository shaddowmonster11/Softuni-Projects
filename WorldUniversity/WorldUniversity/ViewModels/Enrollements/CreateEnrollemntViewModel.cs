using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Enrollements
{
    public class CreateEnrollemntViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        public string StudentGrade { get; set; }
    }
}
