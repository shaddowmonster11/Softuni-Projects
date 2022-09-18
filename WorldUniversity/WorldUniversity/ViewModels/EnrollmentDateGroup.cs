using System;
using System.Collections.Generic;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.ViewModels
{
    public class EnrollmentDateGroup
    {
        public ICollection<GetCoursesDetailsViewModel> Courses { get; set; }
    }
}
