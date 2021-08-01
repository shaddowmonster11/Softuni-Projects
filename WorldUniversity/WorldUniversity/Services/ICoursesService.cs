using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public interface ICoursesService
    {
        Task EnrollStudent(string studentId
            , int courseId
            , string studentCourseGrade);
        IEnumerable<AssignedCourseData> GetAll();
        Task Create(CourseInputModel input);
        GetCoursesDetailsViewModel GetCoursesDetails(int id);
        Task DeleteCourse(int id);
        ICollection<CourseViewModel> GetAllCourses();
        Task UpdateCourse(int Id, string title, int credits, int departmentId);
        bool CourseExists(string name);
    }
}
