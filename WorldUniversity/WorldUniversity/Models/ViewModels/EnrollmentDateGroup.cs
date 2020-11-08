using System;
using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Models.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
    }
}
