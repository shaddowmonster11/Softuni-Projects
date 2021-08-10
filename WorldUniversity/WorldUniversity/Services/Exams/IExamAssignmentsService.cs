using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public interface IExamAssignmentsService
    {
        Task AssignExam(string userId);
        ICollection<ExamAssignmentViewModel> GetAllExamAssignments();
        bool ExamAssignmentExist(int examId, int courseId);
        ExamAssignmentViewModel GetExamAssignmentByExamId(int examId);
    }
}
