using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        public SelectList InstructorNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FirstMidName");

            await _context.SaveChangesAsync();
            //var departmentsQuery = from d in _context.Instructors orderby d.FullName select d;
            //DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
            //InstructorNameSL = new SelectList(departmentsQuery.AsTracking(), "ID", "FullName");

            return RedirectToPage("./Index");
        }
    }
}
