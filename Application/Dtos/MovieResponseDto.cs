using Domain.Entities;
using Domain.Enums;

namespace Application.Dtos
{
    public class MovieResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public MovieType Type { get; set; }
        public string Category { get; set; }
        public string genre { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public List<Domain.Entities.Review> Reviews { get; set; }
    }
}
