namespace Application.Dtos
{
    public class MovieQueryDto
    {
        public string? Category {  get; set; }

        public string? Genre { get; set; }

        public int? ReleaseYear { get; set; }

        public double? MinRating { get; set; }
        
        public string? Search {  get; set; } 

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? SortBy { get; set; }
        public bool SortDescending { get; set; }=true;
    }
    
}
