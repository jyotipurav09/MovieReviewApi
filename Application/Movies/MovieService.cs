using Application.Dtos;
using Application.Movies;
using Domain.Entities;


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
        
            public async Task<List<MovieResponseDto>> GetMoviesAsync(MovieQueryDto query)
            {
                var movies = await _movieRepository.GetAllAsync(); 

               
                if (!string.IsNullOrEmpty(query.Category))
                    movies = movies.Where(m => m.Category == query.Category).ToList();

                if (!string.IsNullOrEmpty(query.Genre))
                    movies = movies.Where(m => m.Genre == query.Genre).ToList();

                if (query.ReleaseYear.HasValue)
                    movies = movies.Where(m => m.ReleaseYear == query.ReleaseYear).ToList();

                if (query.MinRating.HasValue)
                    movies = movies.Where(m => m.Rating >= query.MinRating).ToList();

                if (!string.IsNullOrEmpty(query.Search))
                    movies = movies.Where(m => m.Title.Contains(query.Search, StringComparison.OrdinalIgnoreCase)).ToList();

                
                if (!string.IsNullOrEmpty(query.SortBy))
                {
                    movies = query.SortBy.ToLower() switch
                    {
                        "rating" => query.SortDescending
                                    ? movies.OrderByDescending(m => m.Rating).ToList()
                                    : movies.OrderBy(m => m.Rating).ToList(),

                        "year" => query.SortDescending
                                    ? movies.OrderByDescending(m => m.ReleaseYear).ToList()
                                    : movies.OrderBy(m => m.ReleaseYear).ToList(),

                        "title" => query.SortDescending
                                    ? movies.OrderByDescending(m => m.Title).ToList()
                                    : movies.OrderBy(m => m.Title).ToList(),

                        _ => movies
                    };
                }

               
                var pagedData = movies
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToList();

                
                return pagedData.Select(m => new MovieResponseDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Title = m.Title,
                    Genre = m.Genre,
                    Category = m.Category,
                    ReleaseYear = m.ReleaseYear,
                    Rating = m.Rating
                }).ToList();
            }

        
        

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteAsync(id);
        }
    }
}