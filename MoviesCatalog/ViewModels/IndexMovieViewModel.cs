using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesCatalog.Models;

namespace MoviesCatalog.ViewModels
{
    public class IndexMovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
