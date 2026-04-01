using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public Role Role { get; set; } = Role.User;
        public bool EmailVerified { get; set; }= false;
        public string? ProfilePhoto {  get; set; }
        public DateTime? Dob {  get; set; }
        public string? Instagram {  get; set; }

        public string? YouTube { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }=DateTime.UtcNow;      
        public List<Review> Reviews { get; set; }







    }
}
