using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.ViewModels.Enrollements
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
