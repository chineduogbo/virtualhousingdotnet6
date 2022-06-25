using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Virtual_Housing.Models.Model
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public DateTime? lastlogin { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
       
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? ImageUrl { get; set; }
    }
}
