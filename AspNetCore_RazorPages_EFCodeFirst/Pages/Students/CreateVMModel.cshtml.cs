using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.DTO.Input;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Students
{
    public class CreateVMModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateVMModel(SchoolContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }


        //另一种防止过度发布的方法
        [BindProperty]
        public StudentInput StudentInput { get; set; }

        public async Task<IActionResult> OnPostAsync2()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentInput);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
