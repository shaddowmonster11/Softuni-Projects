using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.Enums;

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
                new Student { FirstName = "Hristomir",     LastName = "Hristov",
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
                new Course {CourseId = 1050, Title = "Basic Algoritms",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics and Science").DepartmentId
                },
                new Course {CourseId = 4022, Title = "Programming C#", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 4041, Title = "Programming java", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 1045, Title = "VSM",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Robotics and Future Science").DepartmentId
                },
                new Course {CourseId = 3141, Title = "Front End",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Robotics and Future Science").DepartmentId
                },
                new Course {CourseId = 2021, Title = "Html",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
                },
                new Course {CourseId = 2042, Title = "CSS",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
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
                    CourseId = courses.Single(c => c.Title == "Basic Algoritms" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Petrov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "VSM" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Stoichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming C#" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Radichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming java" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Radichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Stoichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Html" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Hristov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "CSS" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Hristov").ID
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
                    CourseId = courses.Single(c => c.Title == "Basic Algoritms" ).CourseId,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Mutafov").Id,
                    CourseId = courses.Single(c => c.Title == "Programming java" ).CourseId,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Stracimirov").Id,
                    CourseId = courses.Single(c => c.Title == "Programming C#" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Randulov").Id,
                    CourseId = courses.Single(c => c.Title == "Basic Algoritms" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Stoqnova").Id,
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Petrov").Id,
                    CourseId = courses.Single(c => c.Title == "Html" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Hristov").Id,
                    CourseId = courses.Single(c => c.Title == "Programming C#" ).CourseId
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Hristov").Id,
                    CourseId = courses.Single(c => c.Title == "Programming java").CourseId,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Mutafov").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming").CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Petrov").Id,
                    CourseId = courses.Single(c => c.Title == "CSS").CourseId,
                    Grade = Grade.B
                    }
                
        };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.Id == e.StudentId &&
                            s.Course.CourseId == e.CourseId).SingleOrDefault();
                
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
