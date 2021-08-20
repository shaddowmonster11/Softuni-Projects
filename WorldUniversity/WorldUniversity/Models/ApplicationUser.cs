using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.Entities;

namespace WorldUniversity.Models
{
    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Enrollments=new HashSet<Enrollment>();
            this.ExamAssignments = new HashSet<ExamAssignment>();
            this.Courses = new HashSet<Course>();
        }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
