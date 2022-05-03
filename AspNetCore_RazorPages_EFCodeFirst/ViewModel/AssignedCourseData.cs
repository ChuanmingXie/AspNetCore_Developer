/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:AssignedCourseData
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/3 22:52:25
*修 改 人:
*修改时间:
*作用描述:已分配课程数据
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.ViewModel
{
    public class AssignedCourseData
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public bool Assigned { get; set; }
    }
}
