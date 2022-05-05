/*****************************************************************************
*项目名称:AspNetCore_MVC_EFCodeFirst.Models
*项目描述:
*类 名 称:Course
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/5 22:20:58
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC_EFCodeFirst.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "课程代码")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "课程名称")]
        public string Title { get; set; }

        [Display(Name = "学分")]
        [Range(0, 5)]
        public int Credits { get; set; }

        [Display(Name ="所属院系")]
        public int DepartmentID { get; set; }

        [Display(Name = "所属院系")]
        public Department Department { get; set; }

        [Display(Name ="学生列表")]
        public ICollection<Enrollment> Enrollments { get; set; }

        [Display(Name ="选课统计")]
        public ICollection<CourseAssignment> CoureAssignments { get; set; }
    }
}
