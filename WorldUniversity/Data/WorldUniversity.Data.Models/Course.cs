using System;
using System.Collections.Generic;
using WorldUniversity.Data.Common.Models;

namespace WorldUniversity.Data.Models
{
    public class Course : IDeletableEntity
    {
        public Course()
        {
            ExamAssignments = new HashSet<ExamAssignment>();
            Enrollments = new HashSet<Enrollment>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}