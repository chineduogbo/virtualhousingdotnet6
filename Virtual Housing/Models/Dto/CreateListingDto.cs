namespace Virtual_Housing.Models.Dto
{
    public class CreateListingDto
    {
        public string? _id { get; set; }

        public bool active { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? PricePerEntry { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public List<IFormFile>? ImageUrl { get; set; }
    }
   
    
}
