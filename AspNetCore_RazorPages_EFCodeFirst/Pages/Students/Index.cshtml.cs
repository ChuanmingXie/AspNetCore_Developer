using AspNetCore_RazorPages_EFCodeFirst.Data;
using AspNetCore_RazorPages_EFCodeFirst.Models;
using AspNetCore_RazorPages_EFCodeFirst.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration Configuration;


        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            _context = context;
        }

        public PaginatedList<Student> Students { get;set; }

        public string NameSort { get; set; }

        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }


        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int?pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = from s in _context.Students select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
            }

            studentIQ = sortOrder switch
            {
                "name_desc" => studentIQ.OrderByDescending(s => s.LastName),
                "Date" => studentIQ.OrderBy(s => s.EnrollmentDate),
                "date_desc" => studentIQ.OrderByDescending(s => s.EnrollmentDate),
                _ => studentIQ.OrderBy(s => s.LastName),
            };
            var pageSize = Configuration.GetValue("PageSize", 4);
            Students = await PaginatedList<Student>.CreateAsync(studentIQ.AsNoTracking(),pageIndex??1,pageSize);
        }
    }
}
