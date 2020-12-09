using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;

namespace WorldUniversity.ViewModels.Students
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
     public ICollection<Enrollment> Enrollments { get; set; }
        public string ShortEnrollemntFormat => EnrollmentDate.ToString("dd-MM-yyyy");
    }
}

