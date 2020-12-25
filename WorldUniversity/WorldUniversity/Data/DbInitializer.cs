using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WorldUniversity.Models;
using WorldUniversity.Models.Enums;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstName = "Ivan",   LastName = "Ivanov",
                    EnrollmentDate = DateTime.Parse("2019-01-01") },
                new Student { FirstName = "Stoqn", LastName = "Mutafov",
                    EnrollmentDate = DateTime.Parse("2019-01-01") },
                new Student { FirstName = "Kaloqn",   LastName = "Stracimirov",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstName = "Ivan",    LastName = "Randulov",
                    EnrollmentDate = DateTime.Parse("2006-01-01") },
                new Student { FirstName = "Minka",    LastName = "Stoqnova",
                    EnrollmentDate = DateTime.Parse("2011-01-01") },
                new Student { FirstName = "Pesho",    LastName = "Petrov",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstName = "Hristomir",    LastName = "Hristov",
                    EnrollmentDate = DateTime.Parse("2004-01-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Stoqn",     LastName = "Hristov",
                    HireDate = DateTime.Parse("2000-03-11") },
                new Instructor { FirstName = "Mesut",    LastName = "Yordanov",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Hristo",   LastName = "Stoichkov",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Yordan", LastName = "Radichkov",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Ivan",   LastName = "Petrov",
                    HireDate = DateTime.Parse("2011-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Mathematics and Science",     Budget = 400000,
                    StartDate = DateTime.Parse("2008-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Hristov").ID },
                new Department { Name = "Design", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Yordanov").ID },
                new Department { Name = "Robotics and Future Science", Budget = 3500000,
                    StartDate = DateTime.Parse("2008-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Stoichkov").ID },
                new Department { Name = "Advanced Programming",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Petrov").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {Title = "Basic Algoritms",Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics and Science").DepartmentId
                },
                new Course {Title = "VSM",Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {Title = "Html",Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },

            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Yordanov").ID,
                    Location = "Sofia" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Hristov").ID,
                    Location = "Sofia" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Petrov").ID,
                    Location = "Stara Zagora" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();
            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    Id = courses.Single(c => c.Title == "Basic Algoritms" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Petrov").ID,
                   Course=courses.Single(c => c.Title == "Basic Algoritms" ),

                    },

            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Ivanov").Id,
                    Grade = Grade.A,
                    Course=courses.Single(c => c.Title == "Basic Algoritms" ),
                    Student= students.Single(s => s.LastName == "Ivanov"),

                },

        };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.Id == e.StudentId &&
                            s.Course.Id == e.Id).SingleOrDefault();

                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }

            context.SaveChanges();
        }
    }
}
