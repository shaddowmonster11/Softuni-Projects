using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
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

        public async Task Create(CourseViewModel input)
        {
            var courses = new Course
            {
                CourseId = input.CourseId,
                DepartmentId= input.DepartmentId,
                Title= input.Title,
                Credits=input.Credits,
            }
            ;
            _context.Add(courses);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
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

        public GetCoursesDetailsViewModel GetCoursesDetails(int id)
        {
            var course = _context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .Select(x=>new GetCoursesDetailsViewModel 
            {
                Title=x.Title,
                CourseId=x.CourseId,
                Credits=x.Credits,           
                DepartmentId=x.DepartmentId,
                Department=x.Department,
            })
            .FirstOrDefault(m => m.CourseId == id);
            return course;
        }

        public IQueryable<Department> PopulateDepartment(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            return departmentsQuery;
        }
    }
}
