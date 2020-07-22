using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCatalog.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string IdentityUserId { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageFileUrl { get; set; }
        public DateTime EditDate { get; set; } = DateTime.Now;
    }
}
