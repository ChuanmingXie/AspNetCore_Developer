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

namespace AspNetCore_MVC_EFCodeFirst.Models
{
    public class Department
    {
        [Display(Name ="院系代码")]
        public int DepartmentID { get; set; }

        [Display(Name="院系名称")]
        public string Name { get; set; }

        [Display(Name="年度预算")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        public decimal Budget { get; set; }

        [Display(Name="成立时间")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime StartDate { get; set; }

        [Display(Name="系主任")]
        public int? InstructorID { get; set; }

        [Display(Name = "系主任")]
        public Instructor Administrator { get; set; }

        [Display(Name="系部课程")]
        public ICollection<Course> Courses { get; set; } 

    }
}