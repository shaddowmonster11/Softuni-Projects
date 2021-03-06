﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
        public string ShortEnrolledDate => EnrollmentDate.ToString("dd-MM-yyyy");
    }
}
