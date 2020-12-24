using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Departments;

namespace WorldUniversity.ViewModels.Courses
{
    public class GetCoursesDetailsViewModel
    {
        [Display(Name = "Number")]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
