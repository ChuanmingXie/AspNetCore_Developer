/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:EnrollmentDateGroup
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/2 9:43:47
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

namespace AspNetCore_RazorPages_EFCodeFirst.ViewModel
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
