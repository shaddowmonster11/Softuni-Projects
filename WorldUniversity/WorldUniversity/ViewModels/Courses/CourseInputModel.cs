using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.ViewModels.Departments;

namespace WorldUniversity.ViewModels.Courses
{
    public class CourseInputModel
    {
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(1, 10)]
        public int Credits { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
    }
}
