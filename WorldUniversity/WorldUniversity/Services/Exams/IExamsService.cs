using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public interface IExamsService
    {
        Task CreateExam(CreateExamInputModel input);
        ExamViewModel GetExamDetails(int id);
        ICollection<ExamViewModel> GetAllExams();
        Task UpdateExam(string title, DateTime date, int ExamId);
        Task ArchieveExam(int id);
        bool ExamExists(string title, DateTime date);
        ExamViewModel GetExamById(int Id);


    }
}
