using System;
using System.ComponentModel.DataAnnotations;
using WorldUniversity.Data.Common.Models;

namespace WorldUniversity.Data.Models
{
    public class OfficeAssignment : IDeletableEntity
    {
        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
