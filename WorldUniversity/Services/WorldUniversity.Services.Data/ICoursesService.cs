using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public interface ICoursesService
    {       
        IEnumerable<AssignedCourseData> GetAll();
        Task Create(CourseInputModel input);
        GetCoursesDetailsViewModel GetCoursesDetails(int id);
        Task DeleteCourse(int id);
        ICollection<CourseViewModel> GetAllCourses();
        Task UpdateCourse(int Id, string title, int credits, int? departmentId);
        bool CourseExists(string name);

    }
}
