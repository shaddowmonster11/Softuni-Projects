using System.Collections.Generic;
using WorldUniversity.Models;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.ViewModels.Exams
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
