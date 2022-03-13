using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCore_MVC.Models;

namespace AspNetCore_MVC.Data
{
    public class MovieUniversityContext : DbContext
    {
        public MovieUniversityContext (DbContextOptions<MovieUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCore_MVC.Models.Movie> Movie { get; set; }
    }
}
