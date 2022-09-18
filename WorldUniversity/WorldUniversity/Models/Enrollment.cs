
using System;
using WorldUniversity.Models.Entities;

namespace WorldUniversity.Models
{
    public class Enrollment: IDeletableEntity
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Grade { get; set; }
        public Course Course { get; set; }
        public ApplicationUser Student { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
