using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCatalog.ViewModels
{
    public class PaginationViewModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
