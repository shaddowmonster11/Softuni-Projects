using WorldUniversity.Web.ViewModels.Courses;
using WorldUniversity.Web.ViewModels.Students;

namespace WorldUniversity.Web.ViewModels.Enrollements
{
    public class EnrollemntViewModel
    {
        public int EnrollemntId { get; set; }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
        public CourseViewModel Course { get; set; }
        public StudentViewModel Student { get; set; }
    }
}
