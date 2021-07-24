using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Questions
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
