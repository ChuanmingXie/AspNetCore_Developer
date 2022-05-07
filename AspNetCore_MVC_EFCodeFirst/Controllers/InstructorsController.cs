using AspNetCore_MVC_EFCodeFirst.Data;
using AspNetCore_MVC_EFCodeFirst.Models;
using AspNetCore_MVC_EFCodeFirst.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC_EFCodeFirst.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            var instructors = from i in _context.Instructors
                              .Include(d => d.OfficeAssignment)
                              .Include(d => d.CourseAssignments)
                                  .ThenInclude(d => d.Course)
                                  .ThenInclude(d => d.Department)
                              .AsNoTracking()
                              .OrderBy(d => d.LastName)
                              select i;
            if (!string.IsNullOrEmpty(searchString))
            {
                instructors = instructors.Where(x => x.LastName.Contains(searchString) || x.FirstMidName.Contains(searchString));
            }
            instructors = sortOrder switch
            {
                "name_desc" => instructors.OrderByDescending(x => x.LastName),
                "date_desc" => instructors.OrderByDescending(x => x.HireDate),
                "date" => instructors.OrderBy(x => x.HireDate),
                _ => instructors.OrderBy(x => x.LastName),
            };
            int pageSize = 3;
            //return View(await _context.Instructors.AsNoTracking().ToListAsync());
            return View(await PaginatedList<Instructor>.CreateAsync(instructors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> DetailsOrigin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        public async Task<IActionResult> Details(int? id, int? courseID)
        {
            var detailVM = new InstructorDetailData();
            var instructors  = await _context.Instructors
                  .Include(i => i.OfficeAssignment)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                    .ThenInclude(i => i.Department)
                  .OrderBy(i => i.LastName)
                  .ToListAsync();
            if (id != null)
            {
                ViewData["InstrcutorID"] = id.Value;
                detailVM.Instructor = instructors.Where(i => i.ID == id.Value).Single();
                detailVM.Courses = detailVM.Instructor.CourseAssignments.Select(s => s.Course);
            }
            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                var selectCourse = detailVM.Courses.Where(x => x.CourseID == courseID).Single();
                await _context.Entry(selectCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (var enrollment in selectCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                detailVM.Enrollments = selectCourse.Enrollments;
            }
            return View(detailVM);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HireDate,ID,LastName,FirstMidName")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HireDate,ID,LastName,FirstMidName")] Instructor instructor)
        {
            if (id != instructor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }
    }
}
