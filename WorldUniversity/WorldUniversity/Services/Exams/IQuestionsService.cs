using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Exams;

namespace WorldUniversity.Services.Exams
{
    public interface IQuestionsService
    {
        Task CreateQuestion(CreateQuestionInputModel input);
        //QuestionViewModel GetQuestionDetails(int id);
        ICollection<QuestionViewModel> GetAllQuestions();
        Task DeleteQuestion(int id);
        bool QuestionExist(string questionContent);
    }
}
