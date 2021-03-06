using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.DTO.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Courses
{
    public class IndexSelectModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexSelectModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseInput> CourseVM { get; set; }

        public async Task OnGet()
        {
            CourseVM = await _context.Courses.Select(p => new CourseInput
            {
                CourseID = p.CourseID,
                Title=p.Title,
                Credits=p.Credits,
                DepartmentName=p.Department.Name
            }).ToListAsync();
        }
    }
}
