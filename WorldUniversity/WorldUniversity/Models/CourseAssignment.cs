namespace WorldUniversity.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }
        public int Id { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
