using Application.Dtos;

namespace Application.Movies
{
    public interface IMovieService
    {
        Task<MovieResponseDto> CreateMovieAsync(CreateMovieDto request);

        Task<MovieResponseDto> GetMovieByIdAsync(int id);

        Task<List<MovieResponseDto>> GetAllMoviesAsync();

        Task<List<MovieResponseDto>> SearchMoviesAsync(string title);

        Task<MovieResponseDto> UpdateMovieAsync(int id, UpdateMovieDto request);

        Task<bool> DeleteMovieAsync(int id);
    }
}