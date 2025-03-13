using eMoviesTickets.Data;
using eMoviesTickets.Data.Services;
using eMoviesTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesService _service;
        public MoviesController(MoviesService service)
        {
            _service = service;
        }

        //Display all movies 
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllasync( n => n.Cinema, p=>p.Producer);
            return View(allMovies);
        }

        //Search a movie using its name or description
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllasync(n => n.Cinema, p => p.Producer);
            if (!string.IsNullOrEmpty(searchString))
            { 
                var filteredMovies = allMovies.Where(n => n.Name.Contains(searchString) || 
                n.Description.Contains(searchString)).ToList();
                return View("Index", filteredMovies);
            }
            return View("Index", allMovies);
        }

        //View the movie details
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _service.GetMovieByIdAsync(Id);
            return View(details);
        }

        //Get method: Loads the create form with dropdown list
        public async Task<IActionResult> Create() {

            var dropdowns = await _service.GetDropdownList();

            ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newmovie) 
        { 
         //var movie = _service.AddNewMovieAsync(newmovie);
            if (!ModelState.IsValid) 
            {
                var dropdowns = await _service.GetDropdownList();

                ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");
                return View(newmovie);
            }
            await _service.AddNewMovieAsync(newmovie);
            return RedirectToAction("Index");
        }

        //GET/Movie/Id
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null)
            {
                return View("NotFound");
            }
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var dropdowns = await _service.GetDropdownList();

            ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");

            return View(response);
        }

        //Update the movie 
        [HttpPost]
        public async Task<IActionResult>Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid) 
            {
                var dropdowns = await _service.GetDropdownList();

                ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");
                return View(movie);
              
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction("Index");
        }
    }
}
