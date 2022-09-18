using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Data.Models;

namespace WorldUniversity.Web.ViewModels.Courses
{
    public class AssignUserToCourseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string StudentId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Credits")]
        public int Credits { get; set; }
        public bool IsAssignedToUser { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
    }
}
