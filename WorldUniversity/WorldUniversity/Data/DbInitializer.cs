using System;
using System.Linq;
using WorldUniversity.Models;

namespace WorldUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;
            }

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
                new CourseAssignment
                {
                    CourseId = courses.Single(c => c.Title == "Basic Algoritms" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Petrov").ID,
                   Course=courses.Single(c => c.Title == "Basic Algoritms" ),
                },
                 new CourseAssignment
                {
                    CourseId = courses.Single(c => c.Title == "VSM" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Hristov").ID,
                   Course=courses.Single(c => c.Title == "VSM" ),
                },
                  new CourseAssignment
                {
                    CourseId = courses.Single(c => c.Title == "Html" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Yordanov").ID,
                   Course=courses.Single(c => c.Title == "Html" ),
                },

            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();
            var students = context.Users.ToList();
            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Ivanov").Id,
                    Grade = "A",
                    Course=courses.Single(c => c.Title == "Basic Algoritms" ),
                    Student= students.Single(s => s.LastName == "Ivanov"),
                },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Mutafov").Id,
                    Grade =  "A",
                    Course=courses.Single(c => c.Title == "Basic Algoritms" ),
                    Student= students.Single(s => s.LastName == "Mutafov"),
                },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Stracimirov").Id,
                    Grade = "A",
                    Course=courses.Single(c => c.Title == "Basic Algoritms" ),
                    Student= students.Single(s => s.LastName == "Stracimirov"),
                },
                 new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Stoqnova").Id,
                    Grade =  "A",
                    Course=courses.Single(c => c.Title == "Html" ),
                    Student= students.Single(s => s.LastName == "Stoqnova"),
                },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Hristov").Id,
                    Grade =  "A",
                    Course=courses.Single(c => c.Title == "Html" ),
                    Student= students.Single(s => s.LastName == "Hristov"),
                },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Petrov").Id,
                    Grade =  "A",
                    Course=courses.Single(c => c.Title == "VSM" ),
                    Student= students.Single(s => s.LastName == "Petrov"),
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
