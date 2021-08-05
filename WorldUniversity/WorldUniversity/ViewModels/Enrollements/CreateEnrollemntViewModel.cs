using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.ViewModels.Enrollements
{
    public class CreateEnrollemntViewModel
    {   
        public string CourseTitle { get; set; }
        [Display(Name = "Student")]
        public string StudentId { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
