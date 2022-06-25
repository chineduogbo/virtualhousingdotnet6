namespace Virtual_Housing.Models.Dto
{
    public class CreateListingDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? PricePerEntry { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public List<IFormFile>? ImageUrl { get; set; }

        public string? Area { get; set; }
        public decimal? PriceRange { get; set; }
        public string? Category { get; set; }
        public string? NoOfRooms { get; set; }
        public string? NoOfBathrooms { get; set; }
    }
   
    
}
