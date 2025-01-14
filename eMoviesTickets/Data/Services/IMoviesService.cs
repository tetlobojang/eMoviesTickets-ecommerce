using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Data.ViewModels;
using eMoviesTickets.Models;

namespace eMoviesTickets.Data.Services
{
    public interface IMoviesService: IBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<MovieDropdownVM> GetDropdownList();
        Task<NewMovieVM> AddNewMovieAsync(NewMovieVM newMovie);
        Task UpdateMovieAsync(NewMovieVM newMovie);
    }
}
