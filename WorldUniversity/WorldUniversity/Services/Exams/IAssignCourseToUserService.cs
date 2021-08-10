using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services.Exams
{
    public interface IAssignCourseToUserService
    {
        Task AssignCourseToUser(string userId, int courseId);
        ICollection<AssignUserToCourseViewModel> GetAllAssignedCoursesToUser();
        bool IsAssignCourseToUser(int courseId);
    }
}
