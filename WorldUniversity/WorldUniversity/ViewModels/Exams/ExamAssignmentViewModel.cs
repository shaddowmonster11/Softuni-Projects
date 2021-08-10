using WorldUniversity.Models;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.ViewModels.Exams
{
    public class ExamAssignmentViewModel
    {
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public Exam Exam { get; set; }
        public ApplicationUser User { get; set; }
    }
}
