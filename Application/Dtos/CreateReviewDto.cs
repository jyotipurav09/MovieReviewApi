using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateReviewDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]

        public ReviewType Type { get; set; }


        public string? Comment { get; set; }

        public int Rating { get; set; }
    }
}
