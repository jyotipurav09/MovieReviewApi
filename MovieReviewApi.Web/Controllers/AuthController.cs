using Application.Auth;
using Application.Dtos;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

     
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto request)
        {
            var users = await _userRepository.GetAllAsync();

           
            if (users.Any(u => u.Email == request.Email))
                return BadRequest("Email already exists");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role
            };

            await _userRepository.AddAsync(user);

            return Ok("User registered successfully");
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(u =>
                u.Email == request.Email && u.Password == request.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

          
            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email
            });
        }
    }
}