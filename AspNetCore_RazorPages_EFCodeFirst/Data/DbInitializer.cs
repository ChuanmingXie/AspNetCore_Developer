/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Data
*项目描述:
*类 名 称:DbInitializer
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/30 18:41:20
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_RazorPages_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Data
{
    public static class DbInitializer
    {
        public static void Initializer(SchoolContext context)
        {
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var alexander = new Student
            {
                FirstMidName = "Carson",
                NickName= "Alexander",
                LastName = "Alexander",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2016-09-01")
            };

            var alonso = new Student
            {
                FirstMidName = "Meredith",
                NickName = "Alonso",
                LastName = "Alonso",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2018-09-01")
            };

            var anand = new Student
            {
                FirstMidName = "Arturo",
                LastName = "Anand",
                NickName = "Anand",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2019-09-01")
            };

            var barzdukas = new Student
            {
                FirstMidName = "Gytis",
                LastName = "Barzdukas",
                NickName = "Barzdukas",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2018-09-01")
            };

            var li = new Student
            {
                FirstMidName = "Yan",
                LastName = "Li",
                NickName = "Li",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2018-09-01")
            };

            var justice = new Student
            {
                FirstMidName = "Peggy",
                LastName = "Justice",
                NickName = "Justice",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2017-09-01")
            };

            var norman = new Student
            {
                FirstMidName = "Laura",
                LastName = "Norman",
                NickName = "Norman",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2019-09-01")
            };

            var olivetto = new Student
            {
                FirstMidName = "Nino",
                LastName = "Olivetto",
                NickName = "Olivetto",
                NativePlace = "ABC",
                EnrollmentDate = DateTime.Parse("2011-09-01")
            };

            var abercrombie = new Instructor
            {
                FirstMidName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11")
            };

            var fakhouri = new Instructor
            {
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06")
            };

            var harui = new Instructor
            {
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01")
            };

            var kapoor = new Instructor
            {
                FirstMidName = "Candace",
                LastName = "Kapoor",
                HireDate = DateTime.Parse("2001-01-15")
            };

            var zheng = new Instructor
            {
                FirstMidName = "Roger",
                LastName = "Zheng",
                HireDate = DateTime.Parse("2004-02-12")
            };

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    Instructor = fakhouri,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    Instructor = harui,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    Instructor = kapoor,
                    Location = "Thompson 304" },
            };

            context.AddRange(officeAssignments);

            var english = new Department
            {
                Name = "English",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = abercrombie
            };

            var mathematics = new Department
            {
                Name = "Mathematics",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = fakhouri
            };

            var engineering = new Department
            {
                Name = "Engineering",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = harui
            };

            var economics = new Department
            {
                Name = "Economics",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = kapoor
            };

            var chemistry = new Course
            {
                CourseID = 1050,
                Title = "Chemistry",
                Credits = 3,
                Department = engineering,
                Instructors = new List<Instructor> { kapoor, harui }
            };

            var microeconomics = new Course
            {
                CourseID = 4022,
                Title = "Microeconomics",
                Credits = 3,
                Department = economics,
                Instructors = new List<Instructor> { zheng }
            };

            var macroeconmics = new Course
            {
                CourseID = 4041,
                Title = "Macroeconomics",
                Credits = 3,
                Department = economics,
                Instructors = new List<Instructor> { zheng }
            };

            var calculus = new Course
            {
                CourseID = 1045,
                Title = "Calculus",
                Credits = 4,
                Department = mathematics,
                Instructors = new List<Instructor> { fakhouri }
            };

            var trigonometry = new Course
            {
                CourseID = 3141,
                Title = "Trigonometry",
                Credits = 4,
                Department = mathematics,
                Instructors = new List<Instructor> { harui }
            };

            var composition = new Course
            {
                CourseID = 2021,
                Title = "Composition",
                Credits = 3,
                Department = english,
                Instructors = new List<Instructor> { abercrombie }
            };

            var literature = new Course
            {
                CourseID = 2042,
                Title = "Literature",
                Credits = 4,
                Department = english,
                Instructors = new List<Instructor> { abercrombie }
            };

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    Student = alexander,
                    Course = chemistry,
                    Grade = Grade.A
                },
                new Enrollment {
                    Student = alexander,
                    Course = microeconomics,
                    Grade = Grade.C
                },
                    new Enrollment {
                    Student = alexander,
                    Course = macroeconmics,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    Student = alonso,
                    Course = calculus,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        Student = alonso,
                    Course = trigonometry,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    Student = alonso,
                    Course = composition,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    Student = anand,
                    Course = chemistry,
                    },
                    new Enrollment {
                    Student = anand,
                    Course = microeconomics,
                    Grade = Grade.B
                    },
                new Enrollment {
                    Student = barzdukas,
                    Course = chemistry,
                    Grade = Grade.B
                },
                    new Enrollment {
                    Student = li,
                    Course = composition,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    Student = justice,
                    Course = literature,
                    Grade = Grade.B
                    }
            };

            context.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
