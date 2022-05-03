/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Models
*项目描述:
*类 名 称:Student
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/28 17:10:44
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_RazorPages_EFCodeFirst.Models
{

    public enum Grade
    {
        A,B,C,D,E
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set;}

        public int CourseID { get; set; }

        /// <summary>
        /// 注册选修记录面向一门课程，因此存在CourseID FK和Course
        /// </summary>
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText ="无等级")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }

        /// <summary>
        /// 注册选修纪律针对一名学生，因此存在StudentID FK属性和student
        /// </summary>
        public Student Student { get; set; }
    }
}