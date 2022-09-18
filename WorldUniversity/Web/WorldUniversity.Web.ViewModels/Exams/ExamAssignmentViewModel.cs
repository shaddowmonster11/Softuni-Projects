using System.Collections.Generic;
using WorldUniversity.Data.Models;
using WorldUniversity.Data.Models.ExamModels;

namespace WorldUniversity.Web.ViewModels.Exams
{
    public class ExamAssignmentViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public Exam Exam { get; set; }
        public ICollection<ApplicationUser> Students { get; set; }
    }
}
