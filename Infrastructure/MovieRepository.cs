using Application.Movies;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>> SearchByTitleAsync(string title)
        {
            return await _context.Movies
                .Where(m => m.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}