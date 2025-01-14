using eMoviesTickets.Data;
using eMoviesTickets.Data.Services;
using eMoviesTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Controllers
{
    public class ProducersController: Controller
    {
        private readonly ProducersService _service;

        public ProducersController(ProducersService service)
        {
            _service = service;
        }

        //Get: AllProducers
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllasync();
            return View(allProducers);
        }

        //Add a new Producer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            { 
                return View(producer); 
            }
            await _service.AddAsync(producer);
            return RedirectToAction("Index");
       
        }

        //GET: Producer/id
        public async Task<IActionResult> Details (int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //GET: Producer/id
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")]Producer producer)
        {
            if (!ModelState.IsValid) 
            { 
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //Delete a producer( Get: Producers/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
