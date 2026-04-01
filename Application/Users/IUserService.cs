using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(CreateUserDto request);

        Task<UserResponseDto> UpdateUserAsync(int id, UpdateUserDto request);

        Task<bool> DeleteUserAsync(int id);

        Task<UserResponseDto> GetUserByIdAsync(int id);   

        Task<List<UserResponseDto>> GetAllUsersAsync();
    }
}