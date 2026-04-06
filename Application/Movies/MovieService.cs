using Application.Dtos;
using Application.Movies;
using Domain.Entities;
//using Infrastructure.Repositories;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieResponseDto> CreateMovieAsync(CreateMovieDto request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
               
            };

            var result = await _movieRepository.AddAsync(movie);

            return new MovieResponseDto
            {
                Id = result.Id,
                Title = result.Title,
                ReleaseYear = result.ReleaseYear,
              
            };
        }

        public async Task<MovieResponseDto> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null) return null;

            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                
            };
        }

        public async Task<List<MovieResponseDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            return movies.Select(m => new MovieResponseDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
               
            }).ToList();
        }

        public async Task<List<MovieResponseDto>> SearchMoviesAsync(string title)
        {
            var movies = await _movieRepository.SearchByTitleAsync(title);

            return movies.Select(m => new MovieResponseDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                
            }).ToList();
        }

        public async Task<MovieResponseDto> UpdateMovieAsync(int id, UpdateMovieDto request)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null) return null;

            movie.Title = request.Title;
            movie.ReleaseYear = request.ReleaseYear;
            

            var updated = await _movieRepository.UpdateAsync(movie);

            return new MovieResponseDto
            {
                Id = updated.Id,
                Title = updated.Title,
                ReleaseYear = updated.ReleaseYear,
              
            };
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteAsync(id);
        }
    }
}