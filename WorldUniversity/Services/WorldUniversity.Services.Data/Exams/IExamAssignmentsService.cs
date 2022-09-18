using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public interface IExamAssignmentsService
    {
        Task Create(int examId, int courseId);
        ICollection<ExamAssignmentViewModel> GetAllExamAssignments();
        bool ExamAssignmentExist(int examId, int courseId);
        ExamAssignmentViewModel GetExamAssignmentByExamId(int examId);
        ICollection<ExamAssignment> GetAllExamAssignmentsByCourseId(int courseId);
        Task AddExamAssigmentToStudent(string userId, int courseId);
    }
}
