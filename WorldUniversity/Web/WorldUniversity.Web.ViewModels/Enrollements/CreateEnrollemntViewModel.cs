using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Web.ViewModels.Courses;
using WorldUniversity.Web.ViewModels.Students;

namespace WorldUniversity.Web.ViewModels.Enrollements
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
