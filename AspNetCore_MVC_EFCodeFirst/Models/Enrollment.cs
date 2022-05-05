/*****************************************************************************
*项目名称:AspNetCore_MVC_EFCodeFirst.Models
*项目描述:
*类 名 称:Student
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/5 21:59:31
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC_EFCodeFirst.Models
{
    public enum Grade
    {
        A, B, C, D, E
    }
    public class Enrollment
    {
        [Display(Name ="注册标记")]
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText ="无等级")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}