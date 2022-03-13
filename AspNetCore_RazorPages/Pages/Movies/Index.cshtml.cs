using AspNetCore_RazorPages.Data;
using AspNetCore_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AspNetCore_RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        /// <summary>
        /// 搜索字段
        /// </summary>
        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }

        /// <summary>
        /// 电影流派list
        /// </summary>
        public SelectList Genres { get; set; }

        /// <summary>
        /// 特定流派
        /// </summary>
        [BindProperty(SupportsGet =true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            // 如果 select 报错则是因为Linq没有引用
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            //Movie = await _context.Movie.ToListAsync();
            Movie = await movies.ToListAsync();
        }
    }
}
