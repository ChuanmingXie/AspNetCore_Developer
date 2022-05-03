/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:InstructorCoursePageModel
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/3 22:57:45
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.ViewModel
{
    public class InstructorCoursePageModel : PageModel
    {
        public List<AssignedCourseData> AssignedCourseDataList;

        public void AssignedCourseDataCheckBox(SchoolContext context, Instructor instructor)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            AssignedCourseDataList = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }
    }
}
