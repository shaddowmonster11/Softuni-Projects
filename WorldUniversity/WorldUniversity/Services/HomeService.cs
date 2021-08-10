using System.Linq;
using WorldUniversity.Data;
using WorldUniversity.ViewModels;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;


        public HomeService(ApplicationDbContext context)
        {
            _context = context;
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
