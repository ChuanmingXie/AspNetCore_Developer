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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore_RazorPages_EFCodeFirst.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50,MinimumLength =3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0;yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name="成立时间")]
        public DateTime StartDate { get; set; }

        public int? InstuctorID { get; set; }

        /// <summary>
        /// 一个院系一个系主任
        /// </summary>
        public Instructor Administrator { get; set; }

        /// <summary>
        /// 一个院系设置多门课程
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}