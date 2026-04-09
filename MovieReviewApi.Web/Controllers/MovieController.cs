using Application.Dtos;
using Application.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

       
        [HttpGet("search")]
        public async Task<IActionResult> Search(string title)
        {
            var result = await _movieService.SearchMoviesAsync(title);
            return Ok(result);
        }

        [Authorize(Roles= "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDto request)
        {
            var movie = await _movieService.CreateMovieAsync(request);
            return Ok(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovieDto request)
        {
            var movie = await _movieService.UpdateMovieAsync(id, request);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _movieService.DeleteMovieAsync(id);

            if (!isDeleted)
                return NotFound();

            return Ok("Movie deleted successfully");
        }
    }
}