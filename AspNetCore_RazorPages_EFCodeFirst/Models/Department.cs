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
        [Display(Name="院系代码")]
        public int DepartmentID { get; set; }

        [StringLength(50,MinimumLength =3)]
        [Display(Name="院系名称")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        [Display(Name="院系预算")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name="成立时间")]
        public DateTime StartDate { get; set; }

        [Display(Name="系主任工号")]
        public int? InstuctorID { get; set; }

        [Timestamp]
        [Display(Name="数据标记")]
        public byte[] ConcurrencyToken { get; set; }

        /// <summary>
        /// 一个院系一个系主任
        /// </summary>
        [Display(Name="系主任")]
        public Instructor Administrator { get; set; }

        /// <summary>
        /// 一个院系设置多门课程
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}