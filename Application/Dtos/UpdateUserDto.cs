using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(100)]
      
        public string FirstName { get; set; }
        [Required] 
        [MaxLength(100)]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        [StringLength(10,MinimumLength =10)]

        public string PhoneNumber { get; set; }
        public Role Role { get; set; } = Role.User;
        public bool EmailVerified { get; set; } = false;
        public string? ProfilePhoto { get; set; }
        public DateTime? Dob { get; set; }
        public string? Instagram { get; set; }

        public string? YouTube { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public List<Domain.Entities.Review> Reviews { get; set; }

    }
}
