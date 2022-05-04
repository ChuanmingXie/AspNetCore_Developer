/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Models
*项目描述:
*类 名 称:Enrollment
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/30 17:55:08
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore_RazorPages_EFCodeFirst.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="课程代码")]
        public int CourseID { get; set; }

        [StringLength(50,MinimumLength =3)]
        [Display(Name = "课程名")]
        public string Title { get; set; }

        [Range(0,5)]
        [Display(Name ="学分")]
        public int Credits { get; set; }
        
        [Display(Name ="院系编号")]
        public int DepartmentID { get; set; }

        [Display(Name ="院系信息")]
        public Department Department { get; set; }

        /// <summary>
        /// 一门课程多个学生选修
        /// </summary>
        public ICollection<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// 一门课程多门老师教
        /// </summary>
        public ICollection<Instructor> Instructors { get; set; }
    }
}