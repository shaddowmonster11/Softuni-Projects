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
    public class InstructorService : IInstructorService
    {
        private readonly ApplicationDbContext _context;

        public InstructorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(GetInstructorsDetailsViewModel input)
        {
         /*   input.CourseAssignments = new List<CourseAssignment>();*/
            var instructor = new Instructor
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                HireDate = input.HireDate,             
                OfficeAssignment = input.OfficeAssignment,
            };
            var courseAssignments = new List<CourseAssignment>();
            for (int i = 0; i < input.SelectedCoursesId.Length; i++)
            {               
                var course = _context.Courses.First(x => x.CourseId == input.SelectedCoursesId[i]);
                var courseAssigment = new CourseAssignment
                {
                    Course = course,
                    Instructor = instructor,
                };
                courseAssignments.Add(courseAssigment);
            }
            instructor.CourseAssignments = courseAssignments;
            await _context.AddAsync(instructor);
            await _context.SaveChangesAsync();
        }

        public GetInstructorsDetailsViewModel GetInstructorsDetails(int id)
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
                    /*    CourseAssignments = x.CourseAssignments,*/
                        OfficeAssignment = x.OfficeAssignment,
                    }
               )
              .FirstOrDefault();
            return instructor;
        }
        public async Task UpdateInstructor(string firstName, string lastName
            , DateTime hireDate, OfficeAssignment officeAssignment
            , ICollection<CourseAssignment> courses, int id)
        {
            var updatedInstructor = _context.Instructors
                .FirstOrDefault(s => s.ID == id);
            updatedInstructor.FirstName = firstName;
            updatedInstructor.LastName = lastName;
            updatedInstructor.HireDate = hireDate;
            updatedInstructor.OfficeAssignment = officeAssignment;
            updatedInstructor.CourseAssignments = courses;
            await _context.SaveChangesAsync();
        }
    }
}
