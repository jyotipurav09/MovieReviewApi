using Application.Reviews;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

      
        
       
        public async Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

     
        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews
                                 .Include(r => r.User)
                                 .Include(r => r.Movie)
                                 .ToListAsync();
        }

        
        public async Task<List<Review>> GetByMovieIdAsync(int movieId)
        {
            return await _context.Reviews
                                 .Where(r => r.MovieId == movieId)
                                 .Include(r => r.User)
                                 .Include(r => r.Movie)
                                 .ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews
                   .Include(r => r.User)
                   .Include(r => r.Movie)
                   .FirstOrDefaultAsync(r => r.Id == id);


        }

       
    }
}