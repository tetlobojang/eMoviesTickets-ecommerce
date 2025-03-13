using eMoviesTickets.Models;

namespace eMoviesTickets.Data.ViewModels
{
    public class MovieDropdownVM
    {

        public MovieDropdownVM() 
        { 
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
        
        }
        public List<Producer> Producers {get; set;}
        public List<Actor> Actors {get; set;}
        public List<Cinema> Cinemas { get; set; }

    }
}
