
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Models;

namespace WorldUniversity.ViewModels.Courses
{
    public class AssignUserToCourseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Credits")]
        public int Credits { get; set; }
        public bool IsAssignedToUser { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
    }
}
