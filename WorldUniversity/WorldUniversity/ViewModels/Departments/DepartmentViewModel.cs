using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Instructors;

namespace WorldUniversity.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [Required]
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
