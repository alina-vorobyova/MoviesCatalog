using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MoviesCatalog.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string IdentityUserId { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageFileUrl { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
