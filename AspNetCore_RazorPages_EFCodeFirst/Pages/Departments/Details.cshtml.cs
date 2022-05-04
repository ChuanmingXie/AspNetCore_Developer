using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCore_RazorPages_EFCodeFirst.Data.SchoolContext _context;

        public DetailsModel(AspNetCore_RazorPages_EFCodeFirst.Data.SchoolContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(x=>x.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
