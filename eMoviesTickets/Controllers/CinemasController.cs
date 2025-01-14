using eMoviesTickets.Data;
using eMoviesTickets.Data.Services;
using eMoviesTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly CinemasService _service;
        public CinemasController (CinemasService service)
        { 
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllasync();
            return View(allCinemas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) 
            {  return View(cinema); }
            await _service.AddAsync(cinema);
            return RedirectToAction("Index");
        }
         public async Task<IActionResult> CinemaDetails(int Id) 
        {
            var CinemaDetails = await _service.GetByIdAsync(Id);
            if (CinemaDetails == null) 
            { return View("NotFound"); }
            return View(CinemaDetails);

        }
        public async Task<IActionResult> Edit(int id) 
        { 
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) { return View("NotFound"); }
            return View(cinemaDetails);
                
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Logo, Name, Description")] Cinema cinema) 
        {
            if (!ModelState.IsValid) 
            { return View("NotFound"); }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> Delete(int Id) {
            var details = await _service.GetByIdAsync(Id);
            if (details == null) {
                return View("NotFound");
             }
            return View(details);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id) {
            var details = await _service.GetByIdAsync(Id);
            if (details == null) { return View("NotFound"); }
            await _service.DeleteAsync(Id);
            return RedirectToAction("Index");

        }
    }
}
