using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Reviews
{
    public interface IReviewService
    {
        Task<ReviewResponseDto> CreateReviewAsync(CreateReviewDto request);
        Task<ReviewResponseDto> UpdateReviewAsync(int id, UpdateReviewDto request);
        Task<bool> DeleteReviewAsync(int id);
        Task<ReviewResponseDto> GetReviewByIdAsync(int id);
        Task<List<ReviewResponseDto>> GetAllReviewsAsync();
        Task<List<ReviewResponseDto>> GetReviewsByMovieIdAsync(int movieId);
    }
}