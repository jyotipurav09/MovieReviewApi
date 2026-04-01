using Domain.Enums;

namespace Domain.Entities
{
    public class Review
    {

        public int Id { get; set; }

        public int UserId { get; set; }
        public ReviewType Type { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; } = false;

        public User User { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int MovieId { get; set; }
        public Movie Movie { get; set; }






    }
}
