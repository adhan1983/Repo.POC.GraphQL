using POC.GraphQL.Repository.Data.Context;
using POC.GraphQL.Service.Models;
using System;
using System.Linq;

namespace POC.GraphQL.Repository.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {

                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Jack",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Memphis",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Artu",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="hand",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Hoops",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Woods",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Steve",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Morgan",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Smith",LastName="McLead",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="john",LastName="Lee",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Aphonso",LastName="Davies",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Lewis",LastName="Moods",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Lee",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Penny",LastName="Aloud",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Frank",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Tevez",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Jackson",LastName="Alex",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Memphis",LastName="Depay",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Mess",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Tobb",LastName="Amend",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Ananka",LastName="Grabbs",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="WoodBurn",LastName="Ben",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Philipe",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Mufasa",LastName="Kill",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Kevin",LastName="Space",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Lara",LastName="Croff",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Ozuna",LastName="Mizu",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Gueye",LastName="Idrissa",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Loki",LastName="Tiger",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Harvest",LastName="Spencer",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Eliah",LastName="Martel",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Aarons",LastName="Green",EnrollmentDate=DateTime.Parse("2001-09-01")},


            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4}
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},

                new Enrollment{StudentID=8,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=9,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=10,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=11,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=12,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=13,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=14,CourseID=1050},
                new Enrollment{StudentID=15,CourseID=1050},
                new Enrollment{StudentID=16,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=17,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=18,CourseID=1045},
                new Enrollment{StudentID=19,CourseID=3141,Grade=Grade.A},

                new Enrollment{StudentID=19,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=20,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=21,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=22,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=22,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=23,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=23,CourseID=1050},
                new Enrollment{StudentID=24,CourseID=1050},
                new Enrollment{StudentID=24,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=25,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=26,CourseID=1045},
                new Enrollment{StudentID=27,CourseID=3141,Grade=Grade.A},

                new Enrollment{StudentID=28,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=29,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=30,CourseID=1045},
                new Enrollment{StudentID=31,CourseID=3141,Grade=Grade.A},

            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
