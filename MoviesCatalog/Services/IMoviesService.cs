using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Services
{
    public interface IMoviesService
    {
        Task<IndexMovieViewModel> GetMoviesAsync(int page);
    }
}
