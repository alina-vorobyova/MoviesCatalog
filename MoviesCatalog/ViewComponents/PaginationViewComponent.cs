using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(
            int totalPages,
            int currentPage,
            string controller,
            string action)
        {
            var model = new PaginationViewModel
            {
                TotalPages = totalPages,
                CurrentPage = currentPage,
                Controller = controller,
                Action = action,
            };

            return View("Default", model);
        }
    }
}
