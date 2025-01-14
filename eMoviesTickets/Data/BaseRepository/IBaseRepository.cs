using eMoviesTickets.Models;
using System.Linq.Expressions;

namespace eMoviesTickets.Data.BaseRepository
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllasync();
        Task<IEnumerable<T>> GetAllasync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task AddAsync(T entity);

        Task DeleteAsync(int id);
        //Task<NewMovieVM> AddMovieAsync(NewMovieVM newMovie);
    }
}
