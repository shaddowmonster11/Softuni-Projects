using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.Enums;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.ViewModels.Enrollements
{
    public class CreateEnrollemntViewModel
    {    
        public string CourseTitle { get; set; }
        [Required]
        [Display(Name = "Student Grade")]
        public string StudentGrade { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
