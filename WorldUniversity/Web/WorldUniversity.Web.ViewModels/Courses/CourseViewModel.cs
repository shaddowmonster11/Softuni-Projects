using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Data.Models;

namespace WorldUniversity.Web.ViewModels.Courses
{
    public class CourseViewModel
    {
        [Display(Name = "Number")]
        public int Id { get; set; }
        [Display(Name = "Title")]

        public string Title { get; set; }
        [Display(Name = "Credits")]
        public int Credits { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ApplicationUser> Students { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
    }
}
