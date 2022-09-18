using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Courses;
using WorldUniversity.Web.ViewModels.Instructors;

namespace WorldUniversity.Services
{
    public class InstructorsService : IInstructorsService
    {
        private readonly ApplicationDbContext _context;

        public InstructorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(GetInstructorsDetailsViewModel input)
        {
            var instructor = new Instructor
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                HireDate = input.HireDate,
                OfficeAssignment = input.OfficeAssignment,
            };

            await _context.AddAsync(instructor);
            await _context.SaveChangesAsync();
        }
      
        public async Task DeleteInstructor(int id)
        {
            var office = await _context.OfficeAssignments
                .FirstOrDefaultAsync(o => o.InstructorId == id);
            if(office!=null)
            {
                _context.OfficeAssignments.Remove(office);
            }
            var courseAssigment = _context.CourseAssignments
                 .Where(o => o.InstructorId == id).ToList();
            foreach (var item in courseAssigment)
            {
                item.IsDeleted = true;
                item.DeletedOn= DateTime.UtcNow;
                _context.Update(item);
            }
            var instructor = await _context.Instructors
            .FirstOrDefaultAsync(m => m.ID == id);

            instructor.IsDeleted = true;
            instructor.DeletedOn=DateTime.UtcNow;
            var departments = await _context.Departments
                    .Where(d => d.InstructorId == id)
                    .ToListAsync();

            departments.ForEach(d => d.InstructorId = null);
            await _context.SaveChangesAsync();
        }

        public ICollection<GetInstructorsDetailsViewModel> GetAllInstructors()
        {
            var instructors = _context.Instructors
              .Include(i => i.OfficeAssignment)
              .Include(i => i.CourseAssignments)
                  .ThenInclude(i => i.Course)
                    .Select(x => new GetInstructorsDetailsViewModel
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        HireDate = x.HireDate,
                        CourseAssignments = x.CourseAssignments.Select(ca => new AssignedCourseData
                        {
                            Id = ca.CourseId,
                            Title = ca.Course.Title,
                        }),
                        OfficeAssignment = x.OfficeAssignment,
                    }
               )
              .ToList();
            return instructors;
        }

        public InstructorIndexData GetInstructorAllData()
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Enrollments)
                            .ThenInclude(i => i.Student)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                .OrderBy(i => i.LastName)
                .ToList();
            return viewModel;
        }

        public GetInstructorsDetailsViewModel GetInstructorsDetails(int? id)
        {
            var instructor = _context.Instructors
                .Where(x => x.ID == id)
              .Include(i => i.OfficeAssignment)
              .Include(i => i.CourseAssignments)
                  .ThenInclude(i => i.Course)
                    .Select(x => new GetInstructorsDetailsViewModel
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        HireDate = x.HireDate,
                        CourseAssignments = x.CourseAssignments.Select(ca => new AssignedCourseData
                        {
                            Id = ca.CourseId,
                            Title = ca.Course.Title,
                        }),
                        OfficeAssignment = x.OfficeAssignment,
                    }
               )
              .FirstOrDefault();
            return instructor;
        }

        public bool InstructorExists(string firstName, string lastName)
        {
            return _context.Instructors.Any(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public List<AssignedCourseData> PopulateAssignedCourseData(GetInstructorsDetailsViewModel instructor,
            ICollection<CourseViewModel> allCourses)
        {
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.Id));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    Id = course.Id,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.Id)
                });
            }
            return viewModel;
        }

        public async Task UpdateInstructor(string firstName, string lastName
            , DateTime hireDate, OfficeAssignment officeAssignment
            , int[] selectedId, int id)
        {
            var updatedInstructor = _context.Instructors
                .Include(x => x.CourseAssignments)
                .Include(x => x.OfficeAssignment)
                .FirstOrDefault(s => s.ID == id);
            updatedInstructor.FirstName = firstName;
            updatedInstructor.LastName = lastName;
            updatedInstructor.HireDate = hireDate;
            updatedInstructor.OfficeAssignment = officeAssignment;
            var listedAssignments = new List<CourseAssignment>();
            if (selectedId != null)
            {
                for (int i = 0; i < selectedId.Length; i++)
                {
                    var course = _context.Courses.First(x => x.Id == selectedId[i]);

                    var courseAssigment = new CourseAssignment
                    {
                        Course = course,
                        CourseId = course.Id,
                        Instructor = updatedInstructor,
                        InstructorId = updatedInstructor.ID,
                    };
                    listedAssignments.Add(courseAssigment);
                }
            }
            updatedInstructor.CourseAssignments = listedAssignments;
            await _context.SaveChangesAsync();
        }
    }
}
