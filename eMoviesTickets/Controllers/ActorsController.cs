using eMoviesTickets.Data;
using eMoviesTickets.Data.Services;
using eMoviesTickets.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController (IActorsService service)
        {
            _service = service;
        }

        //Retrieve a list of actors
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllasync();
            return View(allActors);
        }


        //create a new Actor
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
           
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        } 


        //Get: ActorsById
        public async Task<IActionResult> ActorDetails(int Id)
        {
            var details =  await _service.GetByIdAsync(Id);
            if(details == null) 
            {
            return View("NotFound");        
            }
            return View(details);

        }

        //Edit the actor details
        public async Task<IActionResult>Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")]Actor actor) 
        {
            if (!ModelState.IsValid) 
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Delete an Actor( Get: Actors/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if(details == null)
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
