using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.ViewModels.Exams
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
        public int ExamId { get; set; }
        public int Marks { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string IsArchived { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
