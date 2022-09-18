using System;
using WorldUniversity.Data.Common.Models;

namespace WorldUniversity.Data.Models
{
    public class CourseAssignment : IDeletableEntity
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
