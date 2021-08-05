using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.ViewModels.Instructors
{
    public class GetInstructorsDetailsViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [BindProperty]
        public IEnumerable<AssignedCourseData> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
        public int[] SelectedCoursesId { get; set; }
        public string ShortHireDateFormat => HireDate.ToString("dd-MM-yyyy");
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
