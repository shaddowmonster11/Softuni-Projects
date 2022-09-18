using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Instructors;

namespace WorldUniversity.Web.ViewModels.Departments
{
    public class DepartmentInputModel
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public Instructor Administractor { get; set; }
        [Required]
        [Display(Name = "Administrator")]
        public int InstructorId { get; set; }
        public ICollection<GetInstructorsDetailsViewModel> Instructors { get; set; }

    }
}
