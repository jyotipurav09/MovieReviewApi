using Domain.Entities;

namespace Application.Movies
{
    public interface IMovieRepository
    {
        Task<Movie> AddAsync(Movie movie);

        Task<Movie> GetByIdAsync(int id);

        Task<List<Movie>> GetAllAsync();

        Task<List<Movie>> SearchByTitleAsync(string title);

        Task<Movie> UpdateAsync(Movie movie);

        Task<bool> DeleteAsync(int id);


    }
}
