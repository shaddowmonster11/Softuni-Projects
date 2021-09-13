using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Questions
{
    public interface IQuestionsService
    {
        Task CreateQuestion(CreateQuestionInputModel input);
        ICollection<QuestionViewModel> GetAllQuestions();
        Task DeleteQuestion(int id);
        QuestionViewModel GetQuestionById(int questionId);
        bool QuestionExist(string questionContent);
    }
}
