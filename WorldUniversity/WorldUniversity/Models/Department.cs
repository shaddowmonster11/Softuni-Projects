using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models
{
    public class Department
    { 
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
        public byte[] RowVersion { get; set; }
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
