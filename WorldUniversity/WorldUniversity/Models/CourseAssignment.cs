using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }
        public int Id { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
