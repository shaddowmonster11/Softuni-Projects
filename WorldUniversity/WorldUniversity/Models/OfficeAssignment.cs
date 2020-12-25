using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}
