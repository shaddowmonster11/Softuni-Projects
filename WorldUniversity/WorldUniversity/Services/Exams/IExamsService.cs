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
        IQueryable<ExamViewModel> GetAllExams();
        Task UpdateExam(string title, string date, int ExamId);//Must add View and more info about the questions
        Task DeleteExam(int id);
        bool ExamExists(string title, string date);
        
         
    }
}
