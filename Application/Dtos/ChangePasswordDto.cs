using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ChangePasswordDto
    {

        [Required]
        public string CurrentPassword { get; set; }= string.Empty;

        [Required(ErrorMessage="Password is required")]

        public string OldPassword { get; set; }
        
        public string NewPassword { get; set; } = string.Empty;

        public string Email { get; set; }
    }
}
