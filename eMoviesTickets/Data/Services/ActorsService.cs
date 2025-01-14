using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context): base(context) { }
        
    }
}
