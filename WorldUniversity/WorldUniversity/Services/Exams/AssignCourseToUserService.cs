using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services.Exams
{
    public class AssignCourseToUserService : IAssignCourseToUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;

        public AssignCourseToUserService(ApplicationDbContext context
            , ICoursesService coursesService)
        {
            _context = context;
            this.coursesService = coursesService;
        }
        public async Task AssignCourseToUser(string userId,int courseId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var course = _context.Courses.FirstOrDefault(x => x.Id == courseId);
            user.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public ICollection<AssignUserToCourseViewModel> GetAllAssignedCoursesToUser()
        {
            throw new NotImplementedException();
        }

        public bool IsAssignCourseToUser(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
