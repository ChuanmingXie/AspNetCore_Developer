/*****************************************************************************
*项目名称:AspNetCore_MVC_EFCodeFirst.Models
*项目描述:
*类 名 称:Instructor
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/5 22:12:33
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
namespace AspNetCore_MVC_EFCodeFirst.Models
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }

        public int CourseID { get; set; }

        public Instructor Instructor { get; set; }

        public Course Course { get; set; }
    }
}