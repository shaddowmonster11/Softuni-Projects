using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WorldUniversity.Data;
using WorldUniversity.ViewModels;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesService coursesService;

        public HomeService(ApplicationDbContext context,ICoursesService coursesService)
        {
            _context = context;
            this.coursesService = coursesService;
        }
        public EnrollmentDateGroup GetGeneralInformation()
        {

            var courses = _context.Courses
            .Select(x => new GetCoursesDetailsViewModel
            {
                Title = x.Title,
                EnrollemntCount = x.Enrollments.Count(),
            })
            .ToList();
            var groups = new EnrollmentDateGroup
            {
                Courses = courses,
                 
            };
            return groups;
        }
    }
}
