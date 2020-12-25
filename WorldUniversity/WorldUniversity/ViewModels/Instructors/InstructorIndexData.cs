using System.Collections.Generic;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.ViewModels.Instructors
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
