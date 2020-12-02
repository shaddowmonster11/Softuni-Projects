using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Instructors;

namespace WorldUniversity.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<GetInstructorsDetailsViewModel> Instructors { get; set; }
    }
}
