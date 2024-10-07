using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieMvcApp.Models;
using MovieStore.Contracts;
using MovieStoreApp.Models;

namespace MovieMvcApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: MoviesController
        public ActionResult Index()
        {
            var result = _movieService.GetMovies();
            return View(result);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var result = _movieService.GetById(id);
            return View(result);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = DateTime.Now.Ticks,
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    IMDBRating = model.IMDBRating,
                    Price = model.Price
                };

                _movieService.AddMovie(movie);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
