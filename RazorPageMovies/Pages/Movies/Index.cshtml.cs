﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;
using RazorPageMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovies.Data.RazorPageMovies1Context _context;

        public IndexModel(RazorPageMovies.Data.RazorPageMovies1Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? searchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            if (_context.Movie != null)
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
        }
    }
}
