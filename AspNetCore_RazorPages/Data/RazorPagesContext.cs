using AspNetCore_RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_RazorPages.Data
{
    public class RazorPagesContext : DbContext
    {
        public RazorPagesContext (DbContextOptions<RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
