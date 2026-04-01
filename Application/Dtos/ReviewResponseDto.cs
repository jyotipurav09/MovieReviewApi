using Domain.Entities;
using Domain.Enums;

namespace Application.Dtos
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }
        public ReviewType Type { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; } = false;

        //public Users Users { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        
       // public Movies Movies { get; set; }

    }
}
