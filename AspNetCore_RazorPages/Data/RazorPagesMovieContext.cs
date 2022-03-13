using AspNetCore_RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_RazorPages.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
