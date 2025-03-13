using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Data.ViewModels;
using eMoviesTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Adding a new movie and saving it
        public async Task<NewMovieVM> AddNewMovieAsync(NewMovieVM newMovie)
        {
            var newmovie = new Movie()
            {
                Name = newMovie.Name,
                Description = newMovie.Description,
                ImageUrl = newMovie.ImageUrl,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
                Price =  newMovie.Price,
                MovieCategory = newMovie.MovieCategory,
                CinemaId = newMovie.CinemaId,
                ProducerId = newMovie.ProducerId
            };
            await _context.AddAsync(newmovie);
            _context.SaveChanges();

            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = newmovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            
            _context.SaveChanges();
            return newMovie;
        }

        //Load dropdown options 
        public async Task<MovieDropdownVM> GetDropdownList()
        {
            var dropdowns = new MovieDropdownVM()
            { 
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c=> c.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(p=>p.FullName).ToListAsync(),

            };

            return dropdowns;
        }

        public async Task<Movie> GetMovieByIdAsync(int Id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == Id);

            return movieDetails;
        }

        //Update an existing movie
        public async Task UpdateMovieAsync(NewMovieVM newMovie)
        {

            //Check if the movie exists 
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == newMovie.Id);
            if (dbMovie != null) 
            {
                dbMovie.Name = newMovie.Name;
                dbMovie.Description = newMovie.Description;
                dbMovie.ImageUrl = newMovie.ImageUrl;
                dbMovie.StartDate = newMovie.StartDate;
                dbMovie.EndDate = newMovie.EndDate;
                dbMovie.Price = newMovie.Price;
                dbMovie.MovieCategory = newMovie.MovieCategory;
                dbMovie.CinemaId = newMovie.CinemaId;
                dbMovie.ProducerId = newMovie.ProducerId;

                await _context.SaveChangesAsync();
            }

            //remove the existing actors
            var existingActorDB = _context.Actors_Movies.Where(n => n.MovieId == newMovie.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorDB);
            await _context.SaveChangesAsync();
  
            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            _context.SaveChanges();

        }
    }
}
