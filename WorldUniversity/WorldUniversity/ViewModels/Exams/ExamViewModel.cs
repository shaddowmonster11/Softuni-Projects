using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Questions;

namespace WorldUniversity.ViewModels.Exams
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Marks { get; set; }
        public string Title { get; set; }
        [DisplayName("Date and Time")]
        public DateTime Date { get; set; }
        public bool IsArchived { get; set; }
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
