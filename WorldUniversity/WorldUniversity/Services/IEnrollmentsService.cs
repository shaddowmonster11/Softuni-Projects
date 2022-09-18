using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public interface IEnrollmentsService
    {
        Task EnrollStudent(string studentId
            , int courseId);
        ICollection<AssignUserToCourseViewModel> GetAllUnAssignedCoursesToUser(string userId);
        ICollection<AssignUserToCourseViewModel> GetAllUserCourses(string userId);
    }
}
