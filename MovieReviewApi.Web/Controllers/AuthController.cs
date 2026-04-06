using Application.Auth;
using Application.Dtos;
using Application.Users;
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
        private readonly IEmailService _emailService;

        public AuthController(IUserRepository userRepository, IJwtService jwtService,IEmailService emailService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _emailService = emailService;
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
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) return NotFound("User not found");

           
            if (user.Password != request.OldPassword)
                return BadRequest("Old password is incorrect");

            
            if (user.Password == request.NewPassword)
                return BadRequest("New password cannot be the same as old password");

          
            user.Password = request.NewPassword;
            await _userRepository.UpdateAsync(user);

            return Ok("Password changed successfully");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) return NotFound("Email not found");

          
            var otp = new Random().Next(100000, 999999).ToString();

            
            user.PasswordOtp = otp;
            user.PasswordOtpExpiry = DateTime.UtcNow.AddMinutes(10);
            await _userRepository.UpdateAsync(user);

          
            await _emailService.SendOtpAsync(user.Email, otp, "Reset your password");

            return Ok("OTP sent to email");
        }

        
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) return NotFound("Email not found");

            
            if (user.PasswordOtp != request.Otp)
                return BadRequest("Invalid OTP");

            if (user.PasswordOtpExpiry < DateTime.UtcNow)
                return BadRequest("OTP expired");

           
            if (user.Password == request.NewPassword)
                return BadRequest("New password cannot be same as old password");

           
            user.Password = request.NewPassword;

          
            user.PasswordOtp = null;
            user.PasswordOtpExpiry = null;

            await _userRepository.UpdateAsync(user);

            return Ok("Password reset successfully");
        }








    }
}