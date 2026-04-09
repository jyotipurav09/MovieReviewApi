using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewResponseDto> CreateReviewAsync(CreateReviewDto request)
        {
            var review = new Review
            {
                Comment = request.Comment,
                Rating = request.Rating,
                Type = request.Type,
                UserId = request.UserId,
                MovieId = request.MovieId
            };

            await _reviewRepository.AddAsync(review);

            return new ReviewResponseDto
            {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                Type = review.Type,
                UserId = review.UserId,
                MovieId = review.MovieId
            };
        }

        public async Task<ReviewResponseDto> UpdateReviewAsync(int id, UpdateReviewDto request)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(id);

            if (existingReview == null)
                return null;

            existingReview.Comment = request.Comment;
            existingReview.Rating = request.Rating;
            existingReview.Type = request.Type;

            await _reviewRepository.UpdateAsync(existingReview);

            return new ReviewResponseDto
            {
                Id = existingReview.Id,
                Comment = existingReview.Comment,
                Rating = existingReview.Rating,
                Type = existingReview.Type,
                UserId = existingReview.UserId,
                MovieId = existingReview.MovieId
            };
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(id);

            if (existingReview == null)
                return false;

            await _reviewRepository.DeleteAsync(id);
            return true;
        }

        public async Task<ReviewResponseDto> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);

            if (review == null)
                return null;

            return new ReviewResponseDto
            {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                Type = review.Type,
                UserId = review.UserId,
                MovieId = review.MovieId
            };
        }

        public async Task<List<ReviewResponseDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();

            return reviews.Select(r => new ReviewResponseDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                Type = r.Type,
                UserId = r.UserId,
                MovieId = r.MovieId
            }).ToList();
        }

        public async Task<List<ReviewResponseDto>> GetReviewsByMovieIdAsync(int movieId)
        {
            var reviews = await _reviewRepository.GetByMovieIdAsync(movieId);

            return reviews.Select(r => new ReviewResponseDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                Type = r.Type,
                UserId = r.UserId,
                MovieId = r.MovieId
            }).ToList();
        }
    }
}