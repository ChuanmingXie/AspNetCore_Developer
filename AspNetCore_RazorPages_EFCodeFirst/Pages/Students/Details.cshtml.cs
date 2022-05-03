using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;

        public DetailsModel(SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course)
                .AsTracking().FirstOrDefaultAsync(m => m.ID==id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
