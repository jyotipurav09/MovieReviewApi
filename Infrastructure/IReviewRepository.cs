using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IReviewRepository
    {
        Task AddAsync(Review review);
        Task<Review> GetByIdAsync(int id);       
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);
        Task<List<Review>> GetAllAsync();
        Task<List<Review>> GetByMovieIdAsync(int movieId);
    }
}