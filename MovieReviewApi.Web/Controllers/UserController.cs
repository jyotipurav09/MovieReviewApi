using Application.Dtos;
using Application.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieReviewApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

      
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto request)
        {
            var result = await _userService.CreateUserAsync(request);
            return Ok(result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto request)
        {
            var result = await _userService.UpdateUserAsync(id, request);

            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (!result)
                return NotFound("User not found");

            return NoContent();
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }
    }
}