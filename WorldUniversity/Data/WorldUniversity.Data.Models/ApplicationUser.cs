using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using WorldUniversity.Data.Common.Models;
using WorldUniversity.Data.Models;

namespace WorldUniversity.Data.Models
{
    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
            Enrollments = new HashSet<Enrollment>();
            ExamAssignments = new HashSet<ExamAssignment>();
        }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ExamAssignment> ExamAssignments { get; set; }
        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
