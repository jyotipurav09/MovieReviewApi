using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UpdateReviewDto
    {
        [Required]
        public ReviewType Type { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}
