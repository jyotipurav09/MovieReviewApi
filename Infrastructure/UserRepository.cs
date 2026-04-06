using Application.Users;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context; 

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // -------- Email OTP --------
        public async Task SaveEmailOtpAsync(int userId, string otp, DateTime expiry)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.EmailOtp = otp;
                user.EmailOtpExpiry = expiry;
                await _context.SaveChangesAsync();
            }
        }





        //public async Task SaveEmailOtpAsync(int userId, string otp, DateTime expiry)
        //{
        //    var user = await _context.Users.FindAsync(userId);
        //    if (user != null)
        //    {
        //        user.EmailOtp = otp;
        //        user.EmailOtpExpiry = expiry;
        //        await _context.SaveChangesAsync();
        //    }
        //}


        //// -------- Password Reset OTP --------
        //public async Task SavePasswordOtpAsync(int userId, string otp, DateTime expiry)
        //{
        //    var user = await _context.Users.FindAsync(userId);
        //    if (user != null)
        //    {
        //        user.PasswordOtp = otp;
        //        user.PasswordOtpExpiry = expiry;
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<bool> VerifyPasswordOtpAsync(int userId, string otp)
        //{
        //    var user = await _context.Users.FindAsync(userId);
        //    if (user == null) return false;
        //    if (user.PasswordOtp != otp) return false;
        //    if (user.PasswordOtpExpiry < DateTime.UtcNow) return false;

        //    // Clear OTP after verification
        //    user.PasswordOtp = null;
        //    user.PasswordOtpExpiry = null;
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}