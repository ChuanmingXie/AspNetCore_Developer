/*****************************************************************************
*项目名称:AspNetCore_MVC_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:InstructorDetailData
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/7 8:56:05
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_MVC_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC_EFCodeFirst.ViewModel
{
    public class InstructorDetailData
    {
        public Instructor Instructor { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
