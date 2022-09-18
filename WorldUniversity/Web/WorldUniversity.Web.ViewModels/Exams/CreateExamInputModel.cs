using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Web.ViewModels.Courses;

namespace WorldUniversity.Web.ViewModels.Exams
{
    public class CreateExamInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
        [Required]
        [Display(Name = "Exam Date")]
        public DateTime Date { get; set; }
    }
}
