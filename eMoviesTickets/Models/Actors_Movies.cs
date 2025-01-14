namespace eMoviesTickets.Models
{
    public class Actors_Movies

    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }


    }
}
