using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.Enums;
using WorldUniversity.ViewModels.Courses;
using WorldUniversity.ViewModels.Enrollements;
using WorldUniversity.ViewModels.Students;

namespace WorldUniversity.Services
{
    public interface ICoursesService
    {
        Task EnrollStudent(string studentFullName, string courseTitle, string studentCourseGrade);
        IEnumerable<AssignedCourseData> GetAll();
        Task Create(CourseInputModel input);
        IQueryable<Department> PopulateDepartment(object selectedDepartment = null);
        GetCoursesDetailsViewModel GetCoursesDetails(int id);
        Task DeleteCourse(int id);
        ICollection<CourseViewModel> GetAllCourses();
        Task UpdateCourse(int Id,string title,int credits,int departmentId);
        bool CourseExists(int id);
    }
}
