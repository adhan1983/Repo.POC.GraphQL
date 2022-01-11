using POC.GraphQL.Repository.Data.Context;
using POC.GraphQL.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.GraphQL.Repository.Data
{
    public static class DbInitializer
    {
        private static readonly string[] FirstNames = new[]
        {
            "Carson", "Meredith", "Arturo", "Gytis", "Yan", "Memphis", "Paredes", "Scheider", "Kevin", "Housin",

            "Adama", "Mabill", "Gil", "Tevez", "Ruan", "Kay", "Steve", "Sancho", "Nado", "Morgan",
        };

        private static readonly string[] LastNames = new[]
        {
            "Alexander", "Alonso", "Anand", "Barzdukas", "Lee", "Li", "Depay", "Wood", "Havest", "Auar",

            "Arnold", "Davies", "Barakee", "Baros", "Hofmman", "Garcia", "OHara", "WoodBurn", "Jean", "Spencer",
        };

        private static readonly DateTime[] dates = new[]
        {
            DateTime.Parse("2005-09-01"),
            DateTime.Parse("2003-09-01"),
            DateTime.Parse("2002-09-01"),
            DateTime.Parse("2002-08-26"),
            DateTime.Parse("2002-05-18"),
            DateTime.Parse("2010-07-08"),
            DateTime.Parse("2019-09-30"),
            DateTime.Parse("2017-07-17")
        };

        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any()) return;

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

            context.Courses.AddRange(courses);

            var students = new List<Student>();

            var rng = new Random();

            for (int i = 1; i < 10000; i++)
            {
                var student = new Student
                {
                    FirstMidName = $"{FirstNames[rng.Next(FirstNames.Length)]} + { i }",
                    LastName = $"{LastNames[rng.Next(LastNames.Length)]} + { i + 1 }",
                    EnrollmentDate = dates[rng.Next(dates.Length)],
                    Enrollments = new List<Enrollment>()
                };

                var randonCurseId = courses[rng.Next(courses.Length)].CourseID;

                var enrollments = new List<Enrollment>();

                if (randonCurseId == 1050 || randonCurseId == 2042)
                {
                    var lst = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.A
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.B
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.C
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.D
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.F
                        }
                    };
                    enrollments.AddRange(lst);

                }
                else if(randonCurseId == 3141 || randonCurseId == 2021)
                {
                    var lst = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.C
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.F
                        }
                    };

                    enrollments.AddRange(lst);
                }
                else
                {
                    var lst = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.B
                        },
                        new Enrollment
                        {
                            StudentID = student.ID, CourseID = courses[rng.Next(courses.Length)].CourseID, Grade = Grade.D
                        }
                    };

                    enrollments.AddRange(lst);
                }

                student.Enrollments.AddRange(enrollments);

                students.Add(student);

                context.Students.AddRange(students);
            }

            context.SaveChanges();

        }
    }
}
