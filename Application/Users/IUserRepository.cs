using Domain.Entities;

namespace Application.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByIdAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<List<User>> GetAllAsync();

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);


        Task SaveEmailOtpAsync(int userId, string otp, DateTime expiry);

        //Task<bool> VerifyEmailOtpAsync(int userId, string otp);


        //Task SavePasswordOtpAsync(int userId, string otp, DateTime expiry);

        //Task<bool> VerifyPasswordOtpAsync(int userId, string otp);
    }
}
