using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ApplicationDbContext _context;
        public CoursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public async Task Create(CourseInputModel input)
        {
            var courses = new Course
            {
                DepartmentId = input.DepartmentId,
                Title = input.Title,
                Credits = input.Credits,
            };
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
                    Id = x.Id,
                })
                .ToList();
            return courses;
        }

        public ICollection<CourseViewModel> GetAllCourses()
        {
            var courses = _context.Courses
                 .Include(c => c.Department)
                 .Select(c => new CourseViewModel
                 {
                     Title = c.Title,
                     Id = c.Id,
                     Credits = c.Credits,
                     Department = c.Department,
                     DepartmentId = c.DepartmentId,
                 })
                 .AsNoTracking()
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
                Id=x.Id,
                Credits=x.Credits,           
                DepartmentId=x.DepartmentId,
                Department=x.Department,
            })
            .FirstOrDefault(m => m.Id == id);
            return course;
        }

        public IQueryable<Department> PopulateDepartment(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            return departmentsQuery;
        }

        public async Task UpdateCourse(int Id, string title, int credits, int departmentId)
        {
           var updatedCourse= _context.Courses
              .FirstOrDefault(s => s.Id == Id);
            updatedCourse.Id = Id;
            updatedCourse.Title = title;
            updatedCourse.Credits = credits;
            updatedCourse.DepartmentId = departmentId;
            _context.Update(updatedCourse);
            await _context.SaveChangesAsync();
        }
    }
}
