using System;
using System.Collections.Generic;
using WorldUniversity.Data.Common.Models;

namespace WorldUniversity.Data.Models
{
    public class Department : IDeletableEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
