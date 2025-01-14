using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Models;

namespace eMoviesTickets.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
    }
}
