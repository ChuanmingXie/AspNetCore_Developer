/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Models
*项目描述:
*类 名 称:OfficeAssignment
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/30 18:05:44
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name ="办公室")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
