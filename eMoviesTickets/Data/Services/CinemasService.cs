using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Models;

namespace eMoviesTickets.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
