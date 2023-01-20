using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.Identity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shreck!!!" };
            var customers = new List<Customer>
            {
                new Customer{  Name="Ahmed" },
                new Customer{  Name="Mohamed" },
            };

            var movieCustomerVMvm = new MovieCustomerVM
            {
                Movie = movie,
                Customers = customers
            };

             return View(movieCustomerVMvm);


        }
        //////////////
        ///

        public ActionResult Index()
        {
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreList = _context.Genres.ToList();
            var movieFormVM = new MovieFormVM
            {
                Genres = genreList,
            };
            return View("MovieForm", movieFormVM);
        }


        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormVM = new MovieFormVM
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", movieFormVM);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.GenreId= movie.GenreId;
                movieInDb.NumberInStock= movie.NumberInStock;

            }
                _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
               if (movie == null) return HttpNotFound();
            var genreList = _context.Genres.ToList();

            var movieFormVM = new MovieFormVM(movie)
            {
                Genres = _context.Genres.ToList(),
            };

            return View("MovieForm", movieFormVM);
        }






        //////////////
        ///
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pag:{0}, Sort={1}", pageIndex, sortBy));
        //}

        /////////Test Route
        [Route("movies/released/{year}/{month}")]  // //:regex(\\d{2}):range(1, 12) 
        public ActionResult ByRelease(int year ,byte month)
        {
            return Content(year + "/" + month);
        }


    }
}