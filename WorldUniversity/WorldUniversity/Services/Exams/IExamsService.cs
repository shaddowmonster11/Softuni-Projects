using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public interface IExamsService
    {
        Task CreateExam(CreateExamInputModel input);
        ExamViewModel GetExamAllDetails(int id);
        ICollection<ExamViewModel> GetAllExams();
        ICollection<ExamViewModel> GetAllUserExams(string userId);
        ExamDetailsViewModel GetExamDetails(int id);
        Task UpdateExam(ExamDetailsViewModel exam);
        Task ArchieveExam(int id);
        bool ExamExists(string title, DateTime date);
        bool ExamIsArchieved(string title);
        ExamViewModel GetExamById(int Id);
        List<AssignedExamData> PopulateAssignedExamData(int courseId,
        ICollection<ExamViewModel> allExams);

    }
}
