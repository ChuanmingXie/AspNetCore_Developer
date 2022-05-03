using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using Microsoft.Extensions.Logging;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(SchoolContext context ,ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id,bool?saveChangeError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            if (saveChangeError.GetValueOrDefault())
            {
                ErrorMessage = String.Format($"删除学生项{id}失败.请重试！");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            try
            {
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }

        }
    }
}
