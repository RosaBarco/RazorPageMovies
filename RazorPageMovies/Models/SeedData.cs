using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;

namespace RazorPageMovies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovies1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageMovies1Context>>()
                ))
            {
                //EN CASO DE CONTEXTO NULO TIENE UN ERROR.
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("NULL RazorPageMovies1Context");
                }

                if(context.Movie.Any())
                {
                    //LA BASE DE DATOS RETORNA TODO LO QUE CONTIENE ESTA CLASE
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Nightmare Before Christmas",
                        RealeseDate = DateTime.Parse("1993-10-29"),
                        Genre = "Animation, Musical",
                        Price = 18,
                        Rated = "PG",
                        Director = "Tim Burton"
                    },
                    new Movie
                    {
                        Title = "Coraline",
                        RealeseDate = DateTime.Parse("2009-02-6"),
                        Genre = "Animation, Terror",
                        Price = 60,
                        Rated = "PG",
                        Director = "Henry Selick"
                    },
                    new Movie
                    {
                        Title = "Charly and the Chocolate Factory",
                        RealeseDate = DateTime.Parse("2005-7-29"),
                        Genre = "Musical, Fantasy",
                        Price = 150,
                        Rated = "PG",
                        Director = "Tim Burton"
                    },
                    new Movie
                    {
                        Title = "James and the Giant Peach",
                        RealeseDate = DateTime.Parse("1996-4-12"),
                        Genre = "Animation, Fantasy",
                        Price = 38,
                        Rated = "PG",
                        Director = "Henry Selick"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

/*
 * Add-Migration InitialCreate
 * Update-Database
 * Add-Migration [Columna]
 */