/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:CourseViewModel
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/3 10:23:25
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.DTO.Input
{
    public class CourseInput
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string DepartmentName { get; set; }
    }
}
