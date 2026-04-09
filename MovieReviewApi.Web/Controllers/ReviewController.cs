using Application.Dtos;
using Application.Reviews;
using Application.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieReviewApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize(Roles ="User")]
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto request)
        {
            var result = await _reviewService.CreateReviewAsync(request);
            return Ok(result);
        }

        [Authorize(Roles ="User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, UpdateReviewDto request)
        {
            var result = await _reviewService.UpdateReviewAsync(id, request);

            if (result == null)
                return NotFound("Review not found");

            return Ok(result);
        }

        [Authorize(Roles ="User,Admin")]
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);

            if (!result)
                return NotFound("Review not found");

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var result = await _reviewService.GetReviewByIdAsync(id);

            if (result == null)
                return NotFound("Review not found");

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await _reviewService.GetAllReviewsAsync();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetReviewsByMovieId(int movieId)
        {
            var result = await _reviewService.GetReviewsByMovieIdAsync(movieId);
            return Ok(result);
        }
    }
}