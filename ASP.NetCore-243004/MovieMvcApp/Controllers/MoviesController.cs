using BusinessLogic.Contracts;
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
        private readonly IPhotoService _photoService;

        public MoviesController(IMovieService movieService, IPhotoService photoService)
        {
            _movieService = movieService;
            _photoService = photoService;
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
        public async Task<ActionResult> Create(CreateMovieViewModel model)
        {
            var imageUrl = await UploadImage(model.Image);

            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = DateTime.Now.Ticks,
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    IMDBRating = model.IMDBRating,
                    Price = model.Price,
                    ImageUrl = imageUrl
                };

                _movieService.AddMovie(movie);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        private async Task<string> UploadImage(IFormFile? file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                try
                {
                    return await _photoService.UploadFile(file.FileName, stream);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Image", ex.Message);
                }
            }
            return string.Empty;
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
