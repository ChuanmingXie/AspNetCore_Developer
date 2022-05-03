using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using AspNetCore_RazorPages_EFCodeFirst.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            DepartmentNameDropDownList(_context);
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();
            if(await TryUpdateModelAsync<Course>(emptyCourse,"course",s=>s.CourseID,s=>s.DepartmentID,s=>s.Title,s=>s.Credits))
            {
                _context.Courses.Add(Course);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            DepartmentNameDropDownList(_context, emptyCourse.DepartmentID);
            return Page();

        }
    }
}
