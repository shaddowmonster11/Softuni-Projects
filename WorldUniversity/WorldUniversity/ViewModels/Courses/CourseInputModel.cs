using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.ViewModels.Courses
{
    public class CourseInputModel
    {
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(0, 10)]
        public int Credits { get; set; }

        public int DepartmentId { get; set; }
    }
}
