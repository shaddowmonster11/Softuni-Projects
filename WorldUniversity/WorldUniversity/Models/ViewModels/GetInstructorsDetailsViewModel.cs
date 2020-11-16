using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.ViewModels
{
    public class GetInstructorsDetailsViewModel
    {
        public int Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }//change format
        [BindProperty]
        public IEnumerable<AssignedCourseData> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
        public int[] SelectedCoursesId { get; set; }
    }
}
