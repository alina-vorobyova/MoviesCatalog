using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MovieCatalogDbContext _context;

        public MoviesService(MovieCatalogDbContext context)
        {
            _context = context;
        }
        public async Task<IndexMovieViewModel> GetMoviesAsync(int page)
        {
            var totalMovies = await _context.Movies.CountAsync();
            var moviesToTake = _context.Movies
                                    .OrderByDescending(x => x.AddDate)
                                    .Skip(page * 10 - 10)
                                    .Take(10);
                               

            var model = new IndexMovieViewModel()
            {
                Movies = moviesToTake,
                TotalResults = totalMovies,
                TotalPages = (int)Math.Ceiling(totalMovies / 10.0),
                CurrentPage = page
            };

            return model;
        }
    }
}
