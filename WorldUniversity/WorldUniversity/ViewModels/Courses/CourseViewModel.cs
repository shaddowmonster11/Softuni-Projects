using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public int CourseId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(0, 10)]
        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
