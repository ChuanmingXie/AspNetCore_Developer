/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.ViewModel
*项目描述:
*类 名 称:DepartmentNamePageModel
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/3 11:43:43
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_RazorPages_EFCodeFirst.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.ViewModel
{
    public class DepartmentNamePageModel:PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void DepartmentNameDropDownList(SchoolContext _context,object selectedDepartment=null)
        {
            var departmentsQuery = from d in _context.Departments orderby d.Name select d;
            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
    }
}
