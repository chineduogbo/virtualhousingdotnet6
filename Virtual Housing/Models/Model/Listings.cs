using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Virtual_Housing.Models.Model
{
    public class Listings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
     
        public bool active { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? PricePerEntry { get; set; }    
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? Area { get; set; }
        public decimal? PriceRange { get; set; }
        public string? Category { get; set; }
        public string? NoOfRooms { get; set; }
        public string? NoOfBathrooms { get; set; }

        public string[] ImageUrl { get; set; }
    }
}
