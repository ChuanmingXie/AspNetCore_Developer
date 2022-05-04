using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly SchoolContext _context;

        public EditModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public SelectList InstructorNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Department = await _context.Departments
                .Include(d => d.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FirstMidName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var departmentToUpdate = await _context.Departments
                .Include(i => i.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (departmentToUpdate == null)
            {
                return HandleDeleteDepartment();
            }
            //departmentToUpdate.ConcurrencyToken = Guid.NewGuid();
            _context.Entry(departmentToUpdate).Property(d => d.ConcurrencyToken).OriginalValue = Department.ConcurrencyToken;
            //Department.ConcurrencyToken = dbValues.ConcurrencyToken;

            if(await TryUpdateModelAsync<Department>(departmentToUpdate
                , "Department", s => s.Name, s => s.StartDate
                , s => s.Budget, s => s.InstuctorID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "无法保存,部门已被删除");
                        return Page();
                    }

                    var dbValues = (Department)databaseEntry.ToObject();
                    await setDbErrorMessage(dbValues, clientValues, _context);

                    Department.ConcurrencyToken=(byte[])dbValues.ConcurrencyToken;
                    ModelState.Remove($"{nameof(Department)}.{nameof(Department.ConcurrencyToken)}");
                }
            }
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstuctorID);
            return Page();
        }

        private async Task setDbErrorMessage(Department dbValues, Department clientValues, SchoolContext context)
        {
            if (dbValues.Name != clientValues.Name)
            {
                ModelState.AddModelError("院系名称", $"当前值:{dbValues.Name}");
            }
            if (dbValues.Budget != clientValues.Budget)
            {
                ModelState.AddModelError("院系预算", $"当前值:{dbValues.Budget}");
            }
            if (dbValues.StartDate != clientValues.StartDate)
            {
                ModelState.AddModelError("成立时间", $"当前值:{dbValues.StartDate}");
            }
            if (dbValues.InstuctorID != clientValues.InstuctorID)
            {
                Instructor dbInstructor = await _context.Instructors.FindAsync(dbValues.InstuctorID);
                ModelState.AddModelError("系主任", $"当前值:{dbInstructor?.FullName}");
            }
            ModelState.AddModelError(string.Empty, "你尝试修改的数据正在被其他用户使用.操作被取消，如果任然想要保存该记录请再次提交");
        }

        private IActionResult HandleDeleteDepartment()
        {
            var deleteDepartment = new Department();
            ModelState.AddModelError(string.Empty, "无法保存，部门已被删除");
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FullName", Department.InstuctorID);
            return Page();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
