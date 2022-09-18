using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Web.ViewModels.Exams
{
    public class AssignedExamData
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
