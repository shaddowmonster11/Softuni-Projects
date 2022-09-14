using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Models;

namespace WorldUniversity.ViewModels.Students
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

