using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Poster {  get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1900,2100)]
        public int ReleaseYear { get; set; }
        [Required]

        public MovieType Type { get; set; }  

        [Required]
        
        public string Category { get; set; }

        [Required]
        public string Genre { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
