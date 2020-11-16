using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ApplicationDbContext _context;

        public CoursesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AssignedCourseData> GetAll()
        {
            var courses = _context.Courses
                .Select(x => new AssignedCourseData
                {
                    Title = x.Title,
                    CourseId = x.CourseId,
                })
                .ToList();
            return courses;
        }
    }
}
