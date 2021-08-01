using WorldUniversity.Models.Enums;

namespace WorldUniversity.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
