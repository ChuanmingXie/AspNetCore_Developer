/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.DTO.Input
*项目描述:
*类 名 称:InstructorInput
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/3 10:26:40
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_RazorPages_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.DTO.Input
{
    public class InstructorInput
    {
        public IEnumerable<Instructor> Instructors { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
