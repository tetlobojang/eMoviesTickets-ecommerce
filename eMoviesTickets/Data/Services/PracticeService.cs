using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Data.ViewModels;
using eMoviesTickets.Models;
using System.Linq.Expressions;

namespace eMoviesTickets.Data.Services
{

    public class PracticeService : EntityBaseRepository<Movie>, IMoviesService 
    {
        private readonly AppDbContext _context;
        public PracticeService(AppDbContext context) : base(context) 
        {
            _context = context;
        }


        //practice adding new movie (DONE!!!!!!)
        public async Task<NewMovieVM> AddNewMovieAsync(NewMovieVM newMovie)
        {
            //New movie details
            var movie = new Movie()
            {
                Id = newMovie.Id,
                Name = newMovie.Name,
                ImageUrl = newMovie.ImageUrl,
                Description = newMovie.Description,
                Price = newMovie.Price,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
                MovieCategory = newMovie.MovieCategory
            };

            await _context.AddAsync(movie);
            _context.SaveChanges();
            //Actor_movies
            foreach (var id in newMovie.ActorIds) 
            {
                var actor_movie = new Actors_Movies()
                {
                    ActorId = id,
                    MovieId = newMovie.Id,
                };
                await _context.Actors_Movies.AddAsync(actor_movie);
            }
            _context.SaveChanges();
            return newMovie;
            //save to dbcontex
        }

        public Task<IEnumerable<Movie>> GetAllasync(params Expression<Func<Movie, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDropdownVM> GetDropdownList()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieAsync(NewMovieVM newMovie)
        {
            var movie = _context.Movies.FirstOrDefault(n =>n.Id==newMovie.Id);
            if (movie != null) 
            {
                movie.Id = newMovie.Id;
                movie.Name = newMovie.Name;
                movie.Description = newMovie.Description;
                movie.Price = newMovie.Price;
                movie.CinemaId = newMovie.CinemaId;
                movie.ProducerId = newMovie.ProducerId;
                movie.StartDate = newMovie.StartDate;
                movie.EndDate = newMovie.EndDate;
                movie.MovieCategory = newMovie.MovieCategory;

               await _context.SaveChangesAsync();
            }
            var actorsDB = _context.Actors_Movies.Where(n=>n.MovieId==newMovie.Id).ToList();
            _context.Actors_Movies.RemoveRange(actorsDB);
            await _context.SaveChangesAsync();

            //add new actorIDs
            foreach(var actorID in newMovie.ActorIds) 
            {
                var updateActors = new Actors_Movies()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorID,
                };
                
                await _context.Actors_Movies.AddAsync(updateActors);
            }

            //save
            _context.SaveChanges();
        }

       

    }
}
