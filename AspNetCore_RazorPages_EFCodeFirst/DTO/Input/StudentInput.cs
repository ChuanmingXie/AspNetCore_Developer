/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.DTO.Input
*项目描述:
*类 名 称:StudentInput
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/1 11:26:09
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
    public class StudentInput
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
