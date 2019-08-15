    using FirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FirstExample.ViewModels;

namespace FirstExample.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Movie=new Movie(),
                Genres=genre
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("New",viewModel);
           
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieUpDb = _context.Movies.Single(c=>c.Id==movie.Id);
                movieUpDb.Name = movie.Name;
                movieUpDb.ReleaseDate = movie.ReleaseDate;
                movieUpDb.DateAdd = movie.DateAdd;
                movieUpDb.GenreId = movie.GenreId;
                movieUpDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movie");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieViewModel
            {
                Movie=movie,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c=>c.Genre).ToList();
            return View(movie);
        }
        public ActionResult MovieDetails(int id)
        {
            var details = _context.Movies.Include(c=>c.Genre).SingleOrDefault(c => c.Id == id);
            return View(details);
        }
        //GET: Movie/Edit/1
        //public ActionResult Edit(int id)
        //{
        //    return Content("id="+id);
        //}
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        //}
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year+"/"+month);
        }
    }
}