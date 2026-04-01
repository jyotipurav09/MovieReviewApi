using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByIdAsync(int id);

        Task<List<User>> GetAllAsync();

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}