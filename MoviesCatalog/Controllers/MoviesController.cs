using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Data;
using MoviesCatalog.Helpers;
using MoviesCatalog.Models;
using MoviesCatalog.Services;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieCatalogDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(MovieCatalogDbContext context, UserManager<IdentityUser> userManager, IMoviesService moviesService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = await _moviesService.GetMoviesAsync(page);

            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            if (loggedUser != null)
                ViewBag.LoggedUserId = loggedUser.Id;

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies
                .Include(m => m.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(movie);
        }


        [Authorize]
        public async Task<IActionResult> Create()
        {
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            if (loggedUser != null)
                ViewBag.LoggedUserId = loggedUser.Id;
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieViewModel)
        {
            var movie = new Movie();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                if (movieViewModel.ImageFile != null)
                {
                    var path = await FileUploadHelper.UploadFile(movieViewModel.ImageFile);
                    movie = _mapper.Map<Movie>(movieViewModel);
                    movie.Poster = path;

                    if (ModelState.IsValid)
                    {
                        _context.Add(movie);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception)
            {
                TempData["FileUploadError"] = "File upload error! Please try again!";
            }
            return View(movieViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            if (loggedUser != null)
                ViewBag.LoggedUserId = loggedUser.Id;

            ViewBag.Poster = movie.Poster;
            var editViewModel = _mapper.Map<EditViewModel>(movie);
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();

            return View(editViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditViewModel editViewModel)
        {
            if (id != editViewModel.Id)
                return NotFound();

            var movie = new Movie();
            var path = string.Empty;
            movie = _mapper.Map<Movie>(editViewModel);
            if (editViewModel.ImageFile != null)
            {
                path = await FileUploadHelper.UploadFile(editViewModel.ImageFile);
                movie.Poster = path;
            }
            else
            {
                if (editViewModel.ImageFileUrl != null)
                    movie.Poster = editViewModel.ImageFileUrl;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(editViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies
                .Include(m => m.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(movie);
        }


        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
