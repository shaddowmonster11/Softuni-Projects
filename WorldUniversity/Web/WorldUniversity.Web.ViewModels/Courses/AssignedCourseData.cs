using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Web.ViewModels.Courses
{
    public class AssignedCourseData
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
