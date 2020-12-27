using System.ComponentModel.DataAnnotations;
using WorldUniversity.Models.Enums;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.ViewModels.Enrollements
{
    public class EnrollemntViewModel
    {
        public int EnrollemntId { get; set; }
        public int Id { get; set; }
        public int StudentId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public CourseViewModel Course { get; set; }
        public StudentViewModel Student { get; set; }
    }
}
