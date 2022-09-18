using System.Collections.Generic;
using WorldUniversity.Web.ViewModels.Courses;

namespace WorldUniversity.Web.ViewModels
{
    public class EnrollmentDateGroup
    {
        public ICollection<GetCoursesDetailsViewModel> Courses { get; set; }
    }
}
