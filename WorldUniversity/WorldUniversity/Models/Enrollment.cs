
namespace WorldUniversity.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Grade { get; set; }
        public Course Course { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
