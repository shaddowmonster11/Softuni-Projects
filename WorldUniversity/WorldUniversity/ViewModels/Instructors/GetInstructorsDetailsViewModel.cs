using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.ViewModels.Instructors
{
    public class GetInstructorsDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        [BindProperty]
        public IEnumerable<AssignedCourseData> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
        public int[] SelectedCoursesId { get; set; }
        public string ShortHireDateFormat => HireDate.ToString("dd-MM-yyyy");
    }
}
